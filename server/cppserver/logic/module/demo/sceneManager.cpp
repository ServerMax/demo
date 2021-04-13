#include "sceneManager.h"

bool sceneManager::initialize(tcore::api::iCore* core)
{
    return false;
}

bool sceneManager::launch(tcore::api::iCore* core)
{
    return false;
}

bool sceneManager::destroy(tcore::api::iCore* core)
{
    return false;
}

iScene* sceneManager::create()
{
    return nullptr;
}

iScene* sceneManager::addConnecter(iConnecter* connecter)
{
    return nullptr;
}

iScene* sceneManager::query(uint64 guid)
{
    return nullptr;
}
