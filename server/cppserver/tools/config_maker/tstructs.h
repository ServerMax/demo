#ifndef __tstructs_h__
#define __tstructs_h__

#include "header.h"

class tstructs {
public:
    tstructs(std::string excel_file) {
        Excel::Book book(excel_file);
        Excel::Sheet* sheet = book.sheet(0);
        if (sheet->rowsCount() < 3 || sheet->columnsCount() < 3) {
            return;
        }

        int32 row = 0;
        do {
            configer::structs::cstruct info;
            info.name = tools::toMultiString(sheet->cell(row++, configer::structs::struct_name_column).getString().c_str());
            info.desc = tools::toMultiString(sheet->cell(row++, configer::structs::struct_desc_column).getString().c_str());
            info.count = sheet->cell(row++, configer::structs::struct_count_column).getDouble();
            for (int32 i = 0; i < info.count; i++) {
                configer::structs::member member;

                member.type = tools::toMultiString(sheet->cell(row, configer::structs::member_type_column).getString().c_str());
                member.name = tools::toMultiString(sheet->cell(row, configer::structs::member_name_column).getString().c_str());
                member.desc = tools::toMultiString(sheet->cell(row++, configer::structs::member_desc_column).getString().c_str());

                info.member.push_back(member);
            }
            _struct_map.insert(std::make_pair(info.name, info));
            row++;
        } while (row < sheet->rowsCount());
    }

    std::map<std::string, configer::structs::cstruct> _struct_map;
};

#endif //__tstructs_h__
