/* 
* File:   main.cpp
* Author : max
*
* Created on 2021-04-13 19:03:26
*/

#include "demo.h"
#include "uuidManager.h"
#include "sceneManager.h"
#include "connecterManager.h"

iConnecterManager* g_connecter_manager = nullptr;
iSceneManager* g_scene_manager = nullptr;
iUuidManager* g_uuid_manager = nullptr;

get_dll_instance;
create_module(demo);
create_module(uuidManager);
create_module(sceneManager);
create_module(connecterManager);
