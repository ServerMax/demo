/* 
* File:   synchronization.cpp
* Author : max
*
* Created on 2021-02-22 13:48:01
*/

#include "synchronization.h"
#include "clientSession.h"

api::iCore * g_core = nullptr;

static std::string s_listen_ip = "";
static int s_listen_port = -1;

bool synchronization::initialize(api::iCore * core) {
    g_core = core;
    
    debug(core, "hello synchronization");

    s_listen_ip = core->getArgs("listen_ip");
    s_listen_port = tools::stringAsInt(core->getArgs("listen_port"));

    core->launchTcpServer(this, s_listen_ip.c_str(), s_listen_port, 16 * kb, 16 * kb);
    return true;
}

bool synchronization::launch(api::iCore * core) {
    return true;
}

bool synchronization::destroy(api::iCore * core) {
    return true;
}

api::iTcpSession* synchronization::onMallocConnection(api::iCore* core, const char* remote_ip, const int32 remote_port) {
    return tnew clientSession;
}

void synchronization::onError(api::iCore* core, api::iTcpSession* session) {

}

void synchronization::onRelease(api::iCore* core) {

}
