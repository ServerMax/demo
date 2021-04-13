#include "tools.h"
#include <unordered_map>
#include <vector>
#include <string>
#include "md5.h"
#include "excel/book.hpp"
#include "excel/exceptions.hpp"
#include "excel/compoundfile/compoundfile_exceptions.hpp"
#include "cfile.h"
using namespace std;

typedef unordered_map<string, string> input_args_map;
static input_args_map _input_args;
static string _out_path;

void parse(int argc, const char** argv) {
	for (int i = 1; i < argc; ++i) {
		tassert(strncmp(argv[i], "--", 2) == 0, "invalid argv %s", argv[i]);

		const char* start = argv[i] + 2;
		const char* equal = strstr(start, "=");
		tassert(equal != nullptr, "invalid argv %s", argv[i]);
		std::string name(start, equal);
		std::string val(equal + 1);
		_input_args[name] = val;
	}
}

const char* getInputArg(const char* name) {
	input_args_map::const_iterator itor = _input_args.find(name);
	if (itor == _input_args.end()) {
		return nullptr;
	}

	return itor->second.c_str();
}

int main(int argc, const char** argv) {
	parse(argc, argv);

	string file_ex = getInputArg("ex");
	string root_path = string(tools::file::getApppath()) + getInputArg("root");
	string out_path = string(tools::file::getApppath()) + getInputArg("out_path");

    const std::string path = tools::file::getApppath();

    tools::file::opaths paths;
    tools::file::onames names;


    int count;
    if (!tools::file::getfiles(root_path.c_str(), file_ex.c_str(), paths, names, count)) {
        tassert(false, "find config xls error");
        return -1;
    }

	std::unordered_map<string, vector<string>> md5_map;

	for (int i = 0; i < paths.size(); i++) {
		std::string md5 = tlib::md5file(paths[i].c_str());
		auto itor = md5_map.find(md5);
		if (itor == md5_map.end()) {
			itor = md5_map.insert(make_pair(md5, vector<string>())).first;
		}

		itor->second.push_back(paths[i]);
	}

	string fileContent;
	for (auto itor = md5_map.begin(); itor != md5_map.end(); itor++) {
		if (itor->second.size() >= 2) {
			fileContent << itor->first << "\n";
			for (int i = 0; i < itor->second.size(); i++) {
				fileContent << "    " << itor->second[i] << "\n";
			}
		}
	}
	
	tlib::cfile compare_file(out_path.c_str());
	compare_file << fileContent.c_str();

	compare_file.save();
	compare_file.close();
    return 0;
}