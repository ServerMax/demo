#ifndef __udper_h__
#define __udper_h__

#include "interface.h"

namespace tcore {

    class udper : public iUdpPipe, public iCompleter {
    public:
        virtual ~udper() {}
        udper(iUdpSession * session, const std::string & ip, const int32 port);

        static udper * create(iUdpSession * session, const std::string & ip, const int32 port);
        void release();

        virtual void cache();
        virtual void load();
        virtual void close();

        virtual void sendto(const char * ip, const int32 port, const void * context, const int32 size);
        virtual void connect(const char * ip, const int32 port);

        virtual void onCompleter(overlappedex * ex, const eCompletion type, const int32 code, const int32 size);

        virtual uint32 getSocket() { return _socket; }

    private:
        bool asyncRecv();

    private:
        char _recv_temp[package_max_size];
        std::queue<oPackage> _send_queue;

        iUdpSession * _session;
        uint32 _socket;

        overlappedex _recv_ex;
        bool _is_cache;
        bool _is_recving;
    };
}

#endif //__udper_h__
