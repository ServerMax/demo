/* 
* File:   demo.h
* Author : max
*
* Created on 2021-04-13 19:03:26
*/

#ifndef __demo_h__
#define __demo_h__

#include "header.h"

class demo : public iDemo, api::iTcpServer {
public:
    virtual ~demo() {}

    virtual bool initialize(api::iCore * core);
    virtual bool launch(api::iCore * core);
    virtual bool destroy(api::iCore * core);

    // Í¨¹ý iTcpServer ¼Ì³Ð
    virtual api::iTcpSession* onMallocConnection(api::iCore* core, const char* remote_ip, const int32 remote_port) override;
    virtual void onError(api::iCore* core, api::iTcpSession* session) override;
    virtual void onRelease(api::iCore* core) override;
};

#endif //__demo_h__