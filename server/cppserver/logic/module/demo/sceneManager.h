#ifndef __sceneManager_h__
#define __sceneManager_h__

#include "header.h"

class sceneManager : public iSceneManager {
public:
    virtual ~sceneManager() {}

    // ͨ�� iSceneManager �̳�
    virtual bool initialize(tcore::api::iCore* core);
    virtual bool launch(tcore::api::iCore* core);
    virtual bool destroy(tcore::api::iCore* core);

    virtual iScene* create();
    virtual iScene* addConnecter(iConnecter* connecter);
    virtual iScene* query(uint64 guid);

};

#endif //__sceneManager_h__
