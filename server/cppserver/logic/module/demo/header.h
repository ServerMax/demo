/* 
* File:   header.h
* Author : max
*
* Created on 2021-04-13 19:03:26
*/

#ifndef __header_h__
#define __header_h__

#include "tools.h"
#include "iDemo.h"

using namespace tcore;

extern api::iCore * g_core;

extern iConnecterManager * g_connecter_manager;
extern iSceneManager* g_scene_manager;
extern iUuidManager* g_uuid_manager;

#endif //__header_h__
