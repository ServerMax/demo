#ifndef __uuidManager_h__
#define __uuidManager_h__

#include "header.h"

class uuidManager : public iUuidManager {
public:
    virtual ~uuidManager() {}



    // Í¨¹ý iUuidManager ¼Ì³Ð
    virtual bool initialize(tcore::api::iCore* core) override;

    virtual bool launch(tcore::api::iCore* core) override;

    virtual bool destroy(tcore::api::iCore* core) override;

    virtual uint64 allocUuid() override;

};

#endif //__uuidManager_h__
