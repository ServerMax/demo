/* 
* File:   tdb.cpp
* Author : max
*
* Created on 2021-03-16 11:14:25
*/

#include "tdb.h"
//#include "include/mysqlx/"

api::iCore* g_core = nullptr;

bool tdb::initialize(api::iCore * core) {
    g_core = core;
    return true;
}

bool tdb::launch(api::iCore * core) {

    Session sess("127.0.0.1", 3306, "root", "peanut", "cpp_test");
    Schema sch = sess.getSchema("test");
    Collection coll = sch.createCollection("c1", true);

    return true;
}

bool tdb::destroy(api::iCore * core) {
    return true;
}