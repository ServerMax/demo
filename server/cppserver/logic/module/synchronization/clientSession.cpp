#include "clientSession.h"

int clientSession::onRecv(api::iCore* core, const char* content, const int size) {
    return 0;
}

void clientSession::onConnected(api::iCore* core) {

}

void clientSession::onDisconnect(api::iCore* core) {
    tdel this;
}

void clientSession::onConnectFailed(api::iCore* core) {

}
