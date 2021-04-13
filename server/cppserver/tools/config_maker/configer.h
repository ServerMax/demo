#ifndef __configer_h__
#define __configer_h__

#include <string>
#include <vector>
#include <map>

namespace configer {

    /*
    * 
    * name eBuilding    desc
    * count    3
    * department_store    1    1.王府井百货
    * tiananmen    2    2.天安门
    * imperial_palace    3    3.故宫
    */

    namespace enums {

        const int enum_name_column = 1;
        const int enum_desc_column = 1;
        const int enum_count_column = 1;

        const int unit_name_column = 0;
        const int unit_value_column = 1;
        const int unit_desc_column = 2;

        struct cunit {
            std::string name;
            int index;
            std::string desc;
        };

        struct cenum {
            std::string name;
            std::string desc;
            int count;
            std::vector<cunit> units;
        };
    };


    /*
    * name oRewardType desc
    * count 2
    * int exp 经验
    * int money 金钱
    */

    namespace structs {
        const int struct_name_column = 1;
        const int struct_desc_column = 1;
        const int struct_count_column = 1;

        const int member_type_column = 0;
        const int member_name_column = 1;
        const int member_desc_column = 2;

        struct member {
            std::string type;
            std::string name;
            std::string desc;
        };

        struct cstruct {
            std::string name;
            int count;
            std::string desc;
            std::vector<member> member;
        };
    }
}

#endif //__configer_h__
