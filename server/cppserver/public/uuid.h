#ifndef __uuid_h__
#define __uuid_h__

#include "tools.h"

class uuid {
public:
    static uuid & getInstance() {
        static uuid oc;
        return oc;
    }

    inline void setmask(uint16 id) {
        mask = id;
    }

    inline uint64 create() {
        uint64 tick = tools::time::getMillisecond();
        index++;
        if (lastTimestamp != tick) {
            index = 0;
            lastTimestamp = tick;
        }
        else {
            if (index == 0) {
                tick = tilNextMillis(lastTimestamp);
            }
        }
        return mask << 48 | ((tick << 24) >> 16) | index;
    }

private:
    uuid() : mask(0), index(0), lastTimestamp(tools::time::getMillisecond()) {}

    uint64 tilNextMillis(int64 lastTimestamp) {
        uint64 timestamp = tools::time::getMillisecond();
        while (timestamp <= lastTimestamp) {
            timestamp = tools::time::getMillisecond();
        }
        return timestamp;
    }

    uint64 mask;
    uint8 index;
    uint64 lastTimestamp;
};

#endif //__uuid_h__
