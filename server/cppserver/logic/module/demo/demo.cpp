/* 
* File:   demo.cpp
* Author : max
*
* Created on 2021-04-13 19:03:26
*/

#include "demo.h"

api::iCore * g_core = nullptr;

bool demo::initialize(api::iCore * core) {
    g_core = core;
    return true;
}

bool demo::launch(api::iCore * core) {
    return true;
}

bool demo::destroy(api::iCore * core) {
    return true;
}

api::iTcpSession* demo::onMallocConnection(api::iCore* core, const char* remote_ip, const int32 remote_port) {
    return nullptr;
}

void demo::onError(api::iCore* core, api::iTcpSession* session) {

}

void demo::onRelease(api::iCore* core) {

}
