#include "tools.h"
#include "header.h"
#include "tenums.h"
#include "tstructs.h"
#include "xmlmaker.h"
#include "jsonmaker.h"
#include "csharp/csharpmaker.h"
#include "ts/tsmaker.h"

int main() {

    const std::string path = tools::file::getApppath();

    tools::file::opaths paths;
    tools::file::onames names;


    int count;
    if (!tools::file::getfiles((path + "/config").c_str(), ".xls", paths, names, count)) {
        tassert(false, "find config xls error");
        return -1;
    }

    for (int i = 0; i < count; i++) {
        if (names[i] == "enums" || names[i] == "structs") {
            continue;
		}
		createxml(paths[i], names[i], path + "/config");
		createjson(paths[i], names[i], path + "/config");
    }

	csharp::maker maker(path + "/config");
    std::string file_content =  maker.create_auto_config_cs();
    tlib::cfile csharp_file((path + "/AutoConfiger.cs").c_str(), true);
    csharp_file << file_content.c_str();
    csharp_file.save();
    csharp_file.close();

	ts::maker tsmaker(path + "/config");
	std::string ts_file_content = tsmaker.create_auto_config_cs();
	tlib::cfile ts_file((path + "/AutoConfiger.ts").c_str(), true);
	ts_file << ts_file_content.c_str();
	ts_file.save();
	ts_file.close();

    return 0;
}