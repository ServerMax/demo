#ifndef __tsmaker_h__
#define __tsmaker_h__

#include "header.h"
#include "tenums.h"
#include "tstructs.h"

namespace ts {
    class maker {
    public:
        maker(std::string config_path) 
            : _enums_info(config_path + "/enums.xls"), _structs_info(config_path + "/structs.xls") {}
        

        std::string create_auto_config_cs();

    private:
        std::string create_enum_content();
        std::string create_struct_content();

        std::string create_logic_content(const std::string path, const std::string name);

        const tenums _enums_info;
        const tstructs _structs_info;
    };
}

#endif //__tsmaker_h__
