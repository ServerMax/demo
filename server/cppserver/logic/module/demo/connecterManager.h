#ifndef __connecterManager_h__
#define __connecterManager_h__

#include "header.h"

class connecterManager : public iConnecterManager {
public:
    virtual ~connecterManager() {}

    // ͨ�� iConnecterManager �̳�
    virtual bool initialize(tcore::api::iCore* core);
    virtual bool launch(tcore::api::iCore* core);
    virtual bool destroy(tcore::api::iCore* core);
    virtual iConnecter* QueryConnecter(uint64 uuid);
};

#endif //__connecterManager_h__
