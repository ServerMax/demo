/* 
* File:   tdb.h
* Author : max
*
* Created on 2021-03-16 11:14:25
*/

#ifndef __tdb_h__
#define __tdb_h__

#include "header.h"

class tdb : public iTdb {
public:
    virtual ~tdb() {}

    virtual bool initialize(api::iCore * core);
    virtual bool launch(api::iCore * core);
    virtual bool destroy(api::iCore * core);
};

#endif //__tdb_h__