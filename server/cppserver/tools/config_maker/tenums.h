#ifndef __tenums_h__
#define __tenums_h__

#include "header.h"

class tenums {
public:
    tenums(std::string excel_file) {
        Excel::Book book(excel_file);
        Excel::Sheet* sheet = book.sheet(0);
        if (sheet->rowsCount() < 3 || sheet->columnsCount() < 3) {
            tassert(false, "read enum.xls %s error", excel_file.c_str());
            return;
        }

        int32 row = 0;
        do {
            configer::enums::cenum info;
            info.name = tools::toMultiString(sheet->cell(row++, configer::enums::enum_name_column).getString().c_str());
            info.desc = tools::toMultiString(sheet->cell(row++, configer::enums::enum_desc_column).getString().c_str());
            info.count = sheet->cell(row++, configer::enums::enum_desc_column).getDouble();
            for (int32 i = 0; i < info.count; i++) {
                configer::enums::cunit unit;

                unit.name = tools::toMultiString(sheet->cell(row, configer::enums::unit_name_column).getString().c_str());
                unit.index = sheet->cell(row, configer::enums::unit_value_column).getDouble();
                unit.desc = tools::toMultiString(sheet->cell(row++, configer::enums::unit_desc_column).getString().c_str());

                info.units.push_back(unit);
            }
            row++;
            _enum_map.insert(std::make_pair(info.name, info));
        } while (row < sheet->rowsCount());
    }

    std::map<std::string, configer::enums::cenum> _enum_map;
};

#endif //__tenums_h__
