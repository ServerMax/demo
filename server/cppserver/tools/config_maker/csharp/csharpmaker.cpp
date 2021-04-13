#include "csharpmaker.h"

using namespace std;

const char* autoconfig_file_content_head =
"using System;\n\
using System.Collections;\n\
using System.Collections.Generic;\n\
using System.Xml;\n\
\n\
public class AutoConfig\n\
{\n";

const char* autoconfig_file_content_end =
"};\n";

std::string csharp::maker::create_auto_config_cs() {
    std::string content = autoconfig_file_content_head;
    content += create_enum_content();
    content += create_struct_content();

    tools::file::opaths paths;
    tools::file::onames names;
    int count;
    if (!tools::file::getfiles((string(tools::file::getApppath()) + "/config").c_str(), ".xls", paths, names, count)) {
        tassert(false, "find config xls error");
        return nullptr;
    }

    for (int i = 0; i < count; i++) {
        if (names[i] == "enums" || names[i] == "structs") {
            continue;
        }
        content += create_logic_content(paths[i], names[i]);
    }

	content += "    public delegate XmlDocument dlgt_xml_load(string path, string name);\n";
	content += "    dlgt_xml_load _xmlloader;\n";


	content += "\n    public AutoConfig(string path, dlgt_xml_load fun)\n";
	content += "    {\n";
	content += "        _xmlloader = fun;\n\n";

    for (int i = 0; i < count; i++) {
        if (names[i] == "enums" || names[i] == "structs") {
            continue;
        }
        content += "        init_config_" + names[i] + "(path);\n";
    }
    content += "    }\n";


    content += autoconfig_file_content_end;
    return content;
}

std::string csharp::maker::create_enum_content() {
    std::string content = "    //enums.xls\n\n";

    for (auto itor = _enums_info._enum_map.begin(); itor != _enums_info._enum_map.end(); itor++) {
        content += std::string("    /*") + itor->second.desc + "*/\n";
        content += std::string("    public enum ") + itor->second.name + "\n    {\n";
        for (auto i = itor->second.units.begin(); i != itor->second.units.end(); i++) {
            content += std::string("        ") + i->name + " = " + tools::intAsString(i->index) + ", /*" + i->desc + "*/\n";
        }
        content += std::string("    };\n\n");
    }

    return content;
}

std::string csharp::maker::create_struct_content() {

    std::string content = "    //structs.xls\n\n";

    for (auto itor = _structs_info._struct_map.begin(); itor != _structs_info._struct_map.end(); itor++) {
        content += std::string("    /*") + itor->second.desc + "*/\n";
        content += std::string("    public class " + itor->second.name + "\n");
        content += "    {\n";

		std::string cst_arg;
        std::string constrct;
        for (auto i = itor->second.member.begin(); i != itor->second.member.end(); i++) {
            content += std::string("        /*") + i->desc + "*/\n";
            content += std::string("        public readonly ") + i->type + " _" + i->name + ";\n";
            cst_arg += i->type + " " + i->name + ", ";

            constrct += "            _" + i->name + " = " + i->name + ";\n";
        }
		cst_arg.pop_back();
        cst_arg.pop_back();

        content += "        public " + itor->second.name + "(" + cst_arg + ") {\n";
        content += constrct;
        content += "        }\n";


        content += "    };\n";
    }

    return content;
}

#define config_execl_name_row 0
#define config_execl_type_row 1
#define config_execl_desc_row 2


std::string csharp::maker::create_logic_content(const std::string path, const std::string name)
{
    Excel::Book book(path);
    Excel::Sheet* sheet = book.sheet(0);

    if (sheet->rowsCount() < 3 && sheet->columnsCount() >= 1) {
        tassert(false, "file %s row or column error", path.c_str());
        return false;
    }

    std::string content = "    //" + name + ".xls\n";
    content += "    public class o_config_" + name + "\n";
    content += "    {\n";

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

        if (type == "int")
            info.type = oColumnInfo::int_;
        else if (type == "float")
            info.type = oColumnInfo::float_;
        else if (type == "string")
            info.type = oColumnInfo::string_;
        else if (_enums_info._enum_map.find(type) != _enums_info._enum_map.end()) {
            info.type = oColumnInfo::enum_;
        } else if (_structs_info._struct_map.find(type) != _structs_info._struct_map.end()) {
            info.type = oColumnInfo::structs_;
        } else {
            tools::osplitres res;
            int count = tools::split(type, "/", res);
            if (count < 2) {
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
                if (res[1] == "int")
                    info.key_type = oColumnInfo::int_;
                else if (res[1] == "float")
                    info.key_type = oColumnInfo::float_;
                else if (res[1] == "string")
                    info.key_type = oColumnInfo::string_;
                else {
                    tassert(false, "type error %s", type.c_str());
                    return nullptr;
                }

                info.value_struct_name = res[2];
            } else {
                tassert(false, "wtf");
                return nullptr;
            }
        }

        column_infos.push_back(info);
    }

    for (auto itor = column_infos.begin(); itor != column_infos.end(); itor++) {
        switch (itor->type) {
        case oColumnInfo::int_:
        case oColumnInfo::float_:
		case oColumnInfo::string_:
		case oColumnInfo::enum_:
		case oColumnInfo::structs_:
            content += (string("        public ") + itor->type_name + " " + itor->name + "; /*" + itor->desc + "*/\n");
            break;
        case oColumnInfo::array_:
            content += (string("        public IList<") + itor->value_struct_name + "> " + itor->name + ";/*" + itor->desc + "*/\n");
            break;
        case oColumnInfo::set_:
            content += (string("        public ISet<") + itor->value_struct_name + "> " + itor->name + ";/*" + itor->desc + "*/\n");
            break;
        case oColumnInfo::map_:
            content += (string("        public IDictionary<") + itor->key_name + ", " + itor->value_struct_name + "> " + itor->name + ";/*" + itor->desc + "*/\n");
            break;
        }
    }

    content += "    }\n";

    content += "    public IDictionary<int, o_config_" + name + "> o_config_" + name + "_map;\n";
    content += "    void init_config_" + name + "(string path)\n";
    content += "    {\n";

    content += "        o_config_" + name + "_map = new Dictionary<int, o_config_" + name + ">();\n\n";
    content += "        XmlDocument doc =  _xmlloader(path, \"" + name + "\");\n";
    content += "        XmlNode root = doc.SelectSingleNode(\"root\");\n\n";

    content += "        XmlNode node = root.FirstChild;\n";
    content += "        while(null != node)\n";
    content += "        {\n";
    content += "            o_config_" + name + " o = new o_config_" + name + "();\n";
    for (auto itor = column_infos.begin(); itor != column_infos.end(); itor++) {
        switch (itor->type) {
        case oColumnInfo::int_:
        {
            content += "            o." + itor->name + " = (int)float.Parse(node.Attributes[\"" + itor->name + "\"].Value);\n";
            break;
        }
        case oColumnInfo::enum_: {
            content += "            o." + itor->name + " = (" + itor->type_name + ")(int)float.Parse(node.Attributes[\"" + itor->name + "\"].Value);\n";
            break;
        }
        case oColumnInfo::float_:
        {
            content += "            o." + itor->name + " = float.Parse(node.Attributes[\"" + itor->name + "\"].Value);\n";
            break;
        }
        case oColumnInfo::string_:
        {
            content += "            o." + itor->name + " = node.Attributes[\"" + itor->name + "\"].Value;\n";
            break;
        }
        case oColumnInfo::structs_: {
            content += "            string[] " + itor->name + "_values = node.Attributes[\"" + itor->name + "\"].Value.Split(',');\n";
			content += "            o." + itor->name + " = new " + itor->type_name + "(\n";
            auto ifind = _structs_info._struct_map.find(itor->type_name);
            for (int i = 0; i < ifind->second.member.size(); i++) {
				if (ifind->second.member[i].type == "int") {
					content += "                (int)float.Parse(" + itor->name + "_values[" + tools::intAsString(i) + "])";
				} else if (ifind->second.member[i].type == "float") {
					content += "                float.Parse(" + itor->name + "_values[" + tools::intAsString(i) + "])";
				} else if (ifind->second.member[i].type == "string") {
					content += "                " + itor->name + "_values[" + tools::intAsString(i) + "]";
				}

                if (i != ifind->second.member.size() - 1) {
                    content += ",";
                }
                content += "\n";
            }

			content += "            );\n";

            break;
        }
        case oColumnInfo::array_:
        {
            content += "\n            o." + itor->name + " = new List<" + itor->value_struct_name + ">();\n";
            content += "            string[] " + itor->name + "_values = node.Attributes[\"" + itor->name + "\"].Value.Split(';');\n";
            content += "            for (int i = 0; i < " + itor->name + "_values.Length; i++)\n";
            content += "            {\n";

            if (itor->value_struct_name == "int") {
                content += "                " + itor->value_struct_name + " oo = (int)float.Parse(" + itor->name + "_values[i]);\n";
            }
            else if (itor->value_struct_name == "float") {
                content += "                " + itor->value_struct_name + " oo = (int)float.Parse(" + itor->name + "_values[i]);\n";
            }
            else if (itor->value_struct_name == "string") {
                content += "                " + itor->value_struct_name + " oo = " + itor->name + "_values[i];\n";
            }
            else {
                auto ifind = _structs_info._struct_map.find(itor->value_struct_name);
                if (ifind != _structs_info._struct_map.end()) {
                    string constrct;
                    content += "                string[] " + itor->value_struct_name + "_values = " + itor->name + "_values[i].Split(',');\n";
                    for (int i = 0; i < ifind->second.member.size(); i++) {
                        if (ifind->second.member[i].type == "int") {
                            constrct += "(int)float.Parse(" + itor->value_struct_name + "_values[" + tools::intAsString(i) + "]), ";
                        }
                        else if (ifind->second.member[i].type == "float") {
                            constrct += "float.Parse(" + itor->value_struct_name + "_values[" + tools::intAsString(i) + "]), ";
                        }
                        else if (ifind->second.member[i].type == "string") {
                            constrct += itor->value_struct_name + "_values[" + tools::intAsString(i) + "], ";
                        }
                        else {
                            constrct += "(" + ifind->second.member[i].type + ")(int)float.Parse(" + itor->value_struct_name + "_values[" + tools::intAsString(i) + "]), ";
                        }
                    }

                    constrct.pop_back();
                    constrct.pop_back();
					content += "                " + itor->value_struct_name + " oo = new " + itor->value_struct_name + "(" + constrct + ");\n";
                }
                else {
                    content += "                " + itor->value_struct_name + " oo = (" + itor->value_struct_name + ")(int)float.Parse(" + itor->name + "_values[i]);\n";
                }
            }

            content += "\n                o." + itor->name + ".Add(oo);\n";
            content += "            }\n";
            break;
        }
        case oColumnInfo::set_: 
        {
            /*
            *  string[] set_string_values = node.Attributes["set_string"].Value.Split(';');
            *  for(int i=0; i<set_string_values.Length;i++)
            *  {
            *      o.set_string.Add(set_string_values[i]);
            *  }
            */

            content += "\n            o." + itor->name + " = new HashSet<" + itor->value_struct_name + ">();\n";
            content += "            string[] " + itor->name + "_values = node.Attributes[\"" + itor->name + "\"].Value.Split(';');\n";
            content += "            for(int i = 0; i<" + itor->name + "_values.Length; i++)\n";
            content += "            {\n";
            if (itor->value_struct_name == "int") {
                content += "                o." + itor->name + ".Add((int)float.Parse(" + itor->name + "_values[i]));\n";
            }
            else if(itor->value_struct_name == "float") {
                content += "                o." + itor->name + ".Add(float.Parse(" + itor->name + "_values[i]));\n";
            }
            else if(itor->value_struct_name == "string") {
                content += "                o." + itor->name + ".Add(" + itor->name + "_values[i]);\n";
            }
            else {
                tassert(false, "error set key type %s", itor->value_struct_name);
            }
            content += "            }\n";
            break;
        }
        case oColumnInfo::map_:
        {
            content += "\n            o." + itor->name + " = new Dictionary<" + itor->key_name + ", " + itor->value_struct_name + ">();\n";
            content += "            string[] " + itor->name + "_values = " + "node.Attributes[\"" + itor->name + "\"].Value.Split(';');\n";
            content += "            for (int i = 0; i < " + itor->name + "_values.Length; i++)\n";
            content += "            {\n";
            content += "                string[] key_value = " + itor->name + "_values[i].Split('|');\n";

            content += "                string[] " + itor->value_struct_name + "_values = key_value[1].Split(',');\n";
 
			if (itor->value_struct_name == "int") {
				content += "                " + itor->value_struct_name + " oo = (int)float.Parse(" + itor->name + "_values[i]);\n";
			}
			else if (itor->value_struct_name == "float") {
				content += "                " + itor->value_struct_name + " oo = (int)float.Parse(" + itor->name + "_values[i]);\n";
			}
			else if (itor->value_struct_name == "string") {
				content += "                " + itor->value_struct_name + " oo = " + itor->name + "_values[i];\n";
			}
            else {
                string constrct;
				auto ifind = _structs_info._struct_map.find(itor->value_struct_name);
				for (int i = 0; i < ifind->second.member.size(); i++) {
					if (ifind->second.member[i].type == "int") {
                        constrct += "(int)float.Parse(" + itor->value_struct_name + "_values[" + tools::intAsString(i) + "]), ";
					}
					else if (ifind->second.member[i].type == "float") {
                        constrct += "float.Parse(" + itor->value_struct_name + "_values[" + tools::intAsString(i) + "]), ";
					}
					else if (ifind->second.member[i].type == "string") {
                        constrct += itor->value_struct_name + "_values[" + tools::intAsString(i) + "], ";
					}
				}

                constrct.pop_back();
                constrct.pop_back();
				content += "                " + itor->value_struct_name + " oo = new " + itor->value_struct_name + "(" + constrct + ");\n";
            }

            content += "\n                o." + itor->name + ".Add((int)float.Parse(key_value[0]), oo);\n";
            content += "            }\n";

            break;
        }
        }
    }

    content += "\n            o_config_" + name + "_map.Add(o.id, o);\n";
    content += "            node = node.NextSibling;\n";
    content += "        }\n";

    /*
    * XmlReader reader = XmlReader.Create(xml_path + "/test.xml");

        XmlDocument doc = new XmlDocument();
        doc.Load(reader);

        XmlNode root = doc.SelectSingleNode("root");

        XmlNode node = root.FirstChild;
        while (null != node)
    */

    content += "    }\n";



    return content;
}
