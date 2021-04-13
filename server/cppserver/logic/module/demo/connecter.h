#ifndef __connecter_h__
#define __connecter_h__

#include "header.h"

class connecter : public api::iTcpSession, iConnecter {
public:
    connecter() : _uuid(0) {}
    virtual ~connecter() {}

    // 通过 iTcpSession 继承
    virtual int onRecv(api::iCore* core, const char* content, const int size);
    virtual void onConnected(api::iCore* core);
    virtual void onDisconnect(api::iCore* core);
    virtual void onConnectFailed(api::iCore* core);

    // 通过 iConnecter 继承
    virtual uint64 getUuid() { return _uuid; }

private:
    uint64 _uuid;
};

#endif //__connecter_h__
