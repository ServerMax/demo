/* 
* File:   iDemo.h
* Author : max
*
* Created on 2021-04-13 19:03:26
*/

#ifndef __iDemo_h__
#define __iDemo_h__

#include "api.h"

class iConnecter {
public:
    virtual ~iConnecter() {}
    virtual uint64 getUuid() = 0;
};

class iConnecterManager : public iModule {
public:
    virtual ~iConnecterManager() {}

    virtual iConnecter* QueryConnecter(uint64 uuid) = 0;
};

class iScene {
public:
    virtual ~iScene() {}
};

class iSceneManager : public iModule {
public:
    virtual ~iSceneManager() {}

    virtual iScene* create() = 0;
    virtual iScene* addConnecter(iConnecter* connecter) = 0;

    virtual iScene* query(uint64 guid) = 0;
};

class iUuidManager : public iModule {
public:
    virtual ~iUuidManager() {}

    virtual uint64 allocUuid() = 0;
};

class iDemo : public iModule {
public:
    virtual ~iDemo() {}
};

#endif //__iDemo_h__
