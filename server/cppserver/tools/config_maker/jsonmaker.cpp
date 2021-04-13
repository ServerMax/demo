#include "jsonmaker.h"

#define config_name_row 0
#define config_type_row 1
#define config_desc_row 2
#define config_data_begin_row 3

bool createjson(const std::string & excel, const std::string & name, const std::string & xml) {
    Excel::Book book(excel);
    Excel::Sheet * sheet = book.sheet(0);

    std::string value;
    std::vector<std::string> column_names;

    value << "{\"root\":[\n";

    if (sheet->rowsCount() < 3 && sheet->columnsCount() >= 1) {
        tassert(false, "file %s row or column error", excel.c_str());
        return false;
    }

    for (int32 i = 0; i < sheet->columnsCount(); i++) {
        std::string name = tools::toMultiString(sheet->cell(config_name_row, i).getString().c_str());
        column_names.push_back(name);
    }


    for (int32 row = config_data_begin_row; row < sheet->rowsCount(); row++) {
        value << "    {";
        std::vector<std::string> datas;
        for (int32 clm = 0; clm < sheet->columnsCount(); clm++) {
            std::string data;
            const Excel::Cell & cell = sheet->cell(row, clm);
            switch (cell.dataType()) {
            case Excel::Cell::DataType::String:
                data = "\"";
                if (tools::toMultiString(cell.getString().c_str()) != "null") {
					data += tools::toMultiString(cell.getString().c_str());
                }
				data += "\"";
                break;
            case Excel::Cell::DataType::Double:
                data = tools::floatAsString(cell.getDouble());
                break;
            case Excel::Cell::DataType::Formula:
                switch (cell.getFormula().valueType()) {
                case Excel::Formula::StringValue:
                    data = tools::toMultiString(cell.getFormula().getString().c_str());
                    break;
                case Excel::Formula::DoubleValue:
                    data = tools::floatAsString(cell.getFormula().getDouble());
                    break;
                default:
                    tassert(false, "unknown formula res type");
                    return false;
                }
                break;
            }
            value << "\"" << column_names[clm] << "\":" << tools::toUtf8(data.c_str());
            if (clm != sheet->columnsCount() - 1) {
                value << ", ";
            }
        }
        if (row == sheet->rowsCount() - 1) {
			value << "}\n";
		} else {
			value << "},\n";
        }
    }

    value << "]}\n";

    std::string xmlpath;
    xmlpath << xml << "/jsonconfig/" << name << ".json";
    tlib::cfile file(xmlpath.c_str(), true);
    file << value.c_str();
    file.save();
    file.close();
    return true;
}
