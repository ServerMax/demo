#ifndef __clientSession_h__
#define __clientSession_h__

#include "header.h"

class clientSession : public api::iTcpSession {
public:
	virtual int onRecv(api::iCore* core, const char* content, const int size);
	virtual void onConnected(api::iCore* core);
	virtual void onDisconnect(api::iCore* core);
	virtual void onConnectFailed(api::iCore* core);
};

#endif //__clientSession_h__
