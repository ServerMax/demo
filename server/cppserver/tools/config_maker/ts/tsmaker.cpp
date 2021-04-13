#include "tsmaker.h"

using namespace std;

const char* ts_file_content_head =
"export namespace AutoConfig {\n";

const char* ts_file_content_end =
"}\n";

std::string ts::maker::create_auto_config_cs() {
    std::string content = ts_file_content_head;
    content += create_enum_content();
    content += create_struct_content();

    tools::file::opaths paths;
    tools::file::onames names;
    int count;
    if (!tools::file::getfiles((string(tools::file::getApppath()) + "/config").c_str(), ".xls", paths, names, count)) {
        tassert(false, "find config xls error");
        return nullptr;
    }


	content += "    export type fun_config_file_load = (path: string, fun:fun_config_file_loaded) => void;\n";
	content += "    export type fun_config_file_loaded = (json: object) => void;\n\n";

    content += "    var expectation : number = " + intAsString(count - 2) + ";\n\n";

    for (int i = 0; i < count; i++) {
        if (names[i] == "enums" || names[i] == "structs") {
            continue;
        }
        content += create_logic_content(paths[i], names[i]);
    }

	content += "\n    export function initilize(path : string, fun: fun_config_file_load) {\n";

    for (int i = 0; i < count; i++) {
        if (names[i] == "enums" || names[i] == "structs") {
            continue;
        }
        content += "        init_config_" + names[i] + "(path, fun);\n";
    }
    content += "    }\n";

    for (int i = 0; i < count; i++) {
		if (names[i] == "enums" || names[i] == "structs") {
			continue;
		}

		content += "\n    export function get_config_" + names[i] + "() {\n";
		content += "        return o_config_" + names[i] + "_map;\n";
		content += "    }\n";
    }

    content += "    export function config_load_completed() : boolean { return expectation == 0;}\n";

    content += ts_file_content_end;
    return content;
}

std::string ts::maker::create_enum_content() {
    std::string content = "    //enums.xls\n\n";

    for (auto itor = _enums_info._enum_map.begin(); itor != _enums_info._enum_map.end(); itor++) {
        content += std::string("    /*") + itor->second.desc + "*/\n";
        content += std::string("    export enum ") + itor->second.name + "{\n";
        for (auto i = itor->second.units.begin(); i != itor->second.units.end(); i++) {
            content += std::string("        ") + i->name + " = " + tools::intAsString(i->index) + ", /*" + i->desc + "*/\n";
        }
        content += std::string("    }\n\n");
    }

    return content;
}

std::string ts::maker::create_struct_content() {

    std::string content = "    //structs.xls\n\n";

    for (auto itor = _structs_info._struct_map.begin(); itor != _structs_info._struct_map.end(); itor++) {
        content += std::string("    /*") + itor->second.desc + "*/\n";
        content += std::string("    export class " + itor->second.name + " {\n");

		std::string constructor_args;
        std::string constructor_content;

        for (auto i = itor->second.member.begin(); i != itor->second.member.end(); i++) {
            content += std::string("        /*") + i->desc + "*/\n";
            if (i->type == "int" || i->type == "float") {
				content += std::string("        readonly _") + i->name + ": number;\n";
                constructor_args += i->name + ": number, ";
            } else {
				content += std::string("        readonly  _") + i->name + ": " + i->type + ";\n";
				constructor_args += i->name + ": " + i->type + ", ";
            }
            constructor_content += "            this._" + i->name + " = " + i->name + ";\n";
        }

		constructor_args.pop_back();
		constructor_args.pop_back();
        content += "        constructor(" + constructor_args + ") {\n";
        content += constructor_content;
        content += "        }\n";

        content += "    }\n";
    }

    return content;
}

#define config_execl_name_row 0
#define config_execl_type_row 1
#define config_execl_desc_row 2


std::string ts::maker::create_logic_content(const std::string path, const std::string name)
{
    Excel::Book book(path);
    Excel::Sheet* sheet = book.sheet(0);

    if (sheet->rowsCount() < 3 && sheet->columnsCount() >= 1) {
        tassert(false, "file %s row or column error", path.c_str());
        return false;
    }

    std::string content = "    //" + name + ".xls\n";
    content += "    export class o_config_" + name + " {\n";

    struct oColumnInfo {
        enum eDataType {
            int_,
            float_,
            string_,
            array_,
            set_,
            map_,
            enum_,
            structs_
        };

        eDataType type;
        string type_name;
        string name;
        eDataType key_type;
        string key_name;
        string value_struct_name;
        string desc;
    };

    std::vector<oColumnInfo> column_infos;

    for (int32 i = 0; i < sheet->columnsCount(); i++) {
        oColumnInfo info;

        string name = tools::toMultiString(sheet->cell(config_execl_name_row, i).getString().c_str());
        string type = tools::toMultiString(sheet->cell(config_execl_type_row, i).getString().c_str());
        string desc = tools::toMultiString(sheet->cell(config_execl_desc_row, i).getString().c_str());

        info.type_name = type;
        info.name = name;
        info.desc = desc;

        if (type == "int") {
			info.type = oColumnInfo::int_;
			info.type_name = "number";
        }
        else if (type == "float") {
			info.type = oColumnInfo::float_;
			info.type_name = "number";
        }
        else if (type == "string")
            info.type = oColumnInfo::string_;
        else {
            tools::osplitres res;
            int count = tools::split(type, "/", res);
            if (count < 0) {
                tassert(false, "type error %s", type.c_str());
                return nullptr;
            }

            if (res[0] == "array") {
                info.type = oColumnInfo::array_;
                info.value_struct_name = res[1];
            }
            else if (res[0] == "set") {
                info.type = oColumnInfo::set_;
                info.value_struct_name = res[1];
            }
            else if (res[0] == "map") {
                info.type = oColumnInfo::map_;
                info.key_name = res[1];
                if (res[1] == "int") {
					info.key_type = oColumnInfo::int_;
                }
                else if (res[1] == "float") {
					info.key_type = oColumnInfo::float_;
                }
                else if (res[1] == "string")
                    info.key_type = oColumnInfo::string_;
                else {
                    tassert(false, "type error %s", type.c_str());
                    return nullptr;
                }

                info.value_struct_name = res[2];
			}
			else if (_enums_info._enum_map.find(res[0]) != _enums_info._enum_map.end()) {
				info.type = oColumnInfo::enum_;
			}
			else if (_structs_info._struct_map.find(res[0]) != _structs_info._struct_map.end()) {
				info.type = oColumnInfo::structs_;
            }
            else {
                tassert(false, "wtf unknown type %s", res[0]);
                return "";
            }
        }

        column_infos.push_back(info);
    }

	std::string constructor_args;
	std::string constructor_content;

    for (auto itor = column_infos.begin(); itor != column_infos.end(); itor++) {
        switch (itor->type) {
        case oColumnInfo::int_:
		case oColumnInfo::float_:
			content += (string("        readonly _") + itor->name + ": number; /*" + itor->desc + "*/\n");
            constructor_args += itor->name + ": number, ";
            break;
        case oColumnInfo::string_:
        case oColumnInfo::enum_:
        case oColumnInfo::structs_:
			content += (string("        readonly _") + itor->name + ": " + itor->type_name + "; /*" + itor->desc + "*/\n");
			constructor_args += itor->name + ": " + itor->type_name + ", ";
            break;
        case oColumnInfo::array_:
            if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
                content += (string("        readonly _") + itor->name + ": Array<number>;/*" + itor->desc + "*/\n");
                constructor_args += itor->name + ": Array<number>, ";
            }
            else {
                content += (string("        readonly _") + itor->name + ": Array<" + itor->value_struct_name + ">;/*" + itor->desc + "*/\n");
                constructor_args += itor->name + ": Array<" + itor->value_struct_name + ">, ";
            }
            break;
        case oColumnInfo::set_:
			if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
				content += (string("        readonly _") + itor->name + ": Set<number>;/*" + itor->desc + "*/\n");
				constructor_args += itor->name + ": Set<number>, ";
            } else {
				content += (string("        readonly _") + itor->name + ": Set<" + itor->value_struct_name + ">;/*" + itor->desc + "*/\n");
				constructor_args += itor->name + ": Set<" + itor->value_struct_name + ">, ";
			}
            break;
        case oColumnInfo::map_: {
            string key_name_ = itor->key_name;
            string value_name_ = itor->value_struct_name;

            if (itor->key_name == "int" || itor->key_name == "float") {
            key_name_ = "number";
            }

            if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
            value_name_ = "number";
            }

            content += (string("        readonly _") + itor->name + ": Map<" + key_name_ + ", " + value_name_ + ">;/*" + itor->desc + "*/\n");
            constructor_args += itor->name + ": Map<" + key_name_ + ", " + value_name_ + ">, ";
            break;
		}
        }

		constructor_content += "            this._" + itor->name + " = " + itor->name + ";\n";
    }

    constructor_args.pop_back();
    constructor_args.pop_back();
    
    content += "\n        constructor(";
    content += constructor_args;
    content += ") {\n";
    content += constructor_content;
    content += "        }\n";

    content += "    }\n\n";

    content += "    var o_config_" + name + "_map : Map<number, o_config_" + name + ">;\n";
    content += "    function config_" + name + "_loaded(json: object): void {\n";

    content += "        o_config_" + name + "_map = new Map<number, o_config_" + name + ">();\n\n";

    content += "        for (let i in json['root']) {\n";
    constructor_args = "";
    for (auto itor = column_infos.begin(); itor != column_infos.end(); itor++) {
        switch (itor->type) {
        case oColumnInfo::int_:
		case oColumnInfo::enum_: {
			content += "            let " + itor->name + ": number = parseInt(json['root'][i][\"" + itor->name + "\"]);\n";
            break;
        }
        case oColumnInfo::float_:
        {
            content += "            let " + itor->name + ": number = parseFloat(json['root'][i][\"" + itor->name + "\"]);\n";
            break;
        }
        case oColumnInfo::string_:
        {
            content += "            let " + itor->name + ": string = json['root'][i][\"" + itor->name + "\"];\n";
            break;
        }

        case oColumnInfo::array_:
        {
            if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
				content += "\n            let " + itor->name + " = new Array<number>();\n";
            } else {
				content += "\n            let " + itor->name + " = new Array<" + itor->value_struct_name + ">();\n";
            }
            content += "            let  " + itor->name + "_ary = json['root'][i][\"" + itor->name + "\"].toString().split(';');\n";
            content += "            for (let i = 0; i < " + itor->name + "_ary.length; i++) {\n";

            if (itor->value_struct_name == "int") {
                content += "                let oo : number = parseInt(" + itor->name + "_ary[i]);\n";
            }
            else if (itor->value_struct_name == "float") {
                content += "                let oo : number = parseFloat(" + itor->name + "_ary[i]);\n";
            }
            else if (itor->value_struct_name == "string") {
                content += "                let oo : " + itor->value_struct_name + " = " + itor->name + "_ary[i];\n";
            }
            else {
				std::string cnstrct_args;
                auto ifind = _structs_info._struct_map.find(itor->value_struct_name);
                if (ifind != _structs_info._struct_map.end()) {
                    content += "                let value_ary = " + itor->name + "_ary[i].toString().split(',');\n";
                    for (int i = 0; i < ifind->second.member.size(); i++) {
                        if (ifind->second.member[i].type == "int") {
                            content += "                let " + ifind->second.member[i].name + ": number = parseInt(value_ary[" + tools::intAsString(i) + "]);\n";
                        }
                        else if (ifind->second.member[i].type == "float") {
                            content += "                let " + ifind->second.member[i].name + ": number = parseFloat(value_ary[" + tools::intAsString(i) + "]);\n";
                        }
                        else if (ifind->second.member[i].type == "string") {
                            content += "                let " + ifind->second.member[i].name + ": string = value_ary[" + tools::intAsString(i) + "];\n";
                        }
                        else {
                            content += "                let " + ifind->second.member[i].name + " = parseInt(value_ary[" + tools::intAsString(i) + "]);\n";
                        }

                        cnstrct_args += ifind->second.member[i].name + ", ";
                    }
					cnstrct_args.pop_back();
					cnstrct_args.pop_back();
                    content += "\n                let oo  = new " + itor->value_struct_name + "(" + cnstrct_args + ");\n";
                }
                else {
                    content += "                " + itor->value_struct_name + " oo = parseInt(" + itor->name + "_values[i]);\n";
                }
            }

            content += "                " + itor->name + ".push(oo);\n";
            content += "            }\n";
            break;
        }
        case oColumnInfo::set_: 
        {
            if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
				content += "\n            let " + itor->name + " = new Set<number>();\n";
			} else {
				content += "\n            let " + itor->name + " = new Set<" + itor->value_struct_name + ">();\n";
            }

            content += "            let " + itor->name + "_ary = json['root'][i][\"" + itor->name + "\"].toString().split(';');\n";
            content += "            for(let i = 0; i<" + itor->name + "_ary.length; i++) {\n";
            if (itor->value_struct_name == "int") {
                content += "                " + itor->name + ".add(parseInt(" + itor->name + "_ary[i]));\n";
            }
			else if (itor->value_struct_name == "float") {
				content += "                " + itor->name + ".add(parseFloat(" + itor->name + "_ary[i]));\n";
            }
            else if(itor->value_struct_name == "string") {
                content += "                " + itor->name + ".add(" + itor->name + "_ary[i]);\n";
            }
            else {
                tassert(false, "error set key type %s", itor->value_struct_name);
            }
            content += "            }\n";
            break;
        }
        case oColumnInfo::map_:
		{
			string key_name_ = itor->key_name;
			string struct_name_ = itor->value_struct_name;

            if (itor->key_name == "int" || itor->key_name == "float") {
                key_name_ = "number";
            }

            if (itor->value_struct_name == "int" || itor->value_struct_name == "float") {
                struct_name_ = "number";
            }


            content += "\n            let " + itor->name + " = new Map<" + key_name_ + ", " + struct_name_ + ">();\n";
            content += "            let " + itor->name + "_ary = " + "json['root'][i][\"" + itor->name + "\"].toString().split(';');\n";
			content += "            for (let i = 0; i < " + itor->name + "_ary.length; i++) {\n";
			content += "                let key_value = " + itor->name + "_ary[i].toString().split('|');\n";
			content += "                let key: number = parseInt(key_value[0]);\n";

            content += "                let value_ary = key_value[1].toString().split(',');\n\n";
 

			if (itor->value_struct_name == "int") {
				content += "                let oo : number = parseInt(" + itor->name + "_ary[i]);\n";
			}
			else if (itor->value_struct_name == "float") {
				content += "                let oo : number = parseFloat(" + itor->name + "_ary[i]);\n";
			}
			else if (itor->value_struct_name == "string") {
				content += "                let oo : string = " + itor->name + "_ary[i];\n";
			}
            else {
				std::string cnstrct_args;
				auto ifind = _structs_info._struct_map.find(itor->value_struct_name);
				for (int i = 0; i < ifind->second.member.size(); i++) {
					if (ifind->second.member[i].type == "int") {
						content += "                let " + ifind->second.member[i].name + ": number = parseInt(value_ary[" + tools::intAsString(i) + "]);\n";
					}
					else if (ifind->second.member[i].type == "float") {
						content += "                let " + ifind->second.member[i].name + ": number = parseFloat(value_ary[" + tools::intAsString(i) + "]);\n";
					}
					else if (ifind->second.member[i].type == "string") {
						content += "                let " + ifind->second.member[i].name + ": string = value_ary[" + tools::intAsString(i) + "];\n";
					}

					cnstrct_args += ifind->second.member[i].name + ", ";
				}

				cnstrct_args.pop_back();
				cnstrct_args.pop_back();

				content += "\n                let oo : " + ifind->second.name + " = new " + ifind->second.name + "(" + cnstrct_args + ");";
            }


            content += "\n                " + itor->name + ".set(key, oo);\n";
            content += "            }\n";

            break;
        }
        case oColumnInfo::structs_: {
			content += "            let " + itor->name + "_value = json['root'][i][\"" + itor->name + "\"].toString().split(',');\n";
            
            string cstrct_content;
            auto ifind = _structs_info._struct_map.find(itor->type_name);
            int member_index = 0;
            for (auto it = ifind->second.member.begin(); it != ifind->second.member.end(); it++) {
                if (it->type == "int") {
                    cstrct_content += "parseInt(" + itor->name + "_value[" + intAsString(member_index) + "]), ";
                }
                else if (it->type == "float") {
					cstrct_content += "parseFloat(" + itor->name + "_value[" + intAsString(member_index) + "]), ";
                }
                else if (it->type == "string") {
					cstrct_content += itor->name + "_value[" + intAsString(member_index) + "],";
                }
                else {
                    tassert(false, "struct member error");
                }
                member_index++;
            }
            cstrct_content.pop_back();

            content += "            let " + itor->name + ": " + itor->type_name + " = new " + itor->type_name + "(" + cstrct_content + ");\n";
            break;
        }
        }

        constructor_args += itor->name + ", ";
    }

    constructor_args.pop_back();
    constructor_args.pop_back();

    content += "\n            o_config_" + name + "_map.set(id, new o_config_" + name + "(" + constructor_args + "));\n";
    content += "        }\n";
    content += "        expectation--;\n";
    content += "    }\n";

    content += "    function init_config_" + name + "(path: string, fun:fun_config_file_load): void {\n";
    content += "        fun(path + \"/" + name + ".json\", config_" + name + "_loaded);\n";
    content += "    }\n";

    return content;
}
