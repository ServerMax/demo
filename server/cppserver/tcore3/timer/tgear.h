#ifndef __tgear_h__
#define __tgear_h__

#include "multisys.h"

namespace tcore {
    class tlist;
    class tgear {
    public:
        tgear(int maxMoveDst, tgear* nextGear);
        ~tgear();

        tlist * getTimerList(int32 index);
        void checkHighGear();
        void update();
        void updateToLowGear();

    private:
        tgear(tgear&);
        tgear& operator =(tgear&);

        tlist * _timerVec;//
        tgear * _nextGear;//
        int32 _curMoveDst;//
        int32 _maxMoveDst;//
    };
}

#endif //__tgear_h__
