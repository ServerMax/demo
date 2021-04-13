#ifndef __tcpser_h__
#define __tcpser_h__

#include "interface.h"

namespace tcore {
    class tcper : public iCompleter, public iTcpPipe {
    public:
        virtual ~tcper() {}

        static tcper * create(api::iTcpSession * session, const int32 sendsize, const int32 recvsize, uint32 sock, bool initiative);

        virtual void onCompleter(overlappedex * ex, const eCompletion type, const int32 code, const int32 size);
        virtual void cache();
        virtual void load();
        virtual void close();
        virtual void send(const void * data, const int32 size, bool immediately);

    private:
        friend tlib::tpool<tcper>;
        tcper(api::iTcpSession * session, const int32 sendsize, const int32 recvsize, uint32 sock);

        bool async_recv();
        bool async_send();

    private:
        bool _sending, _recving, _caching;

        char _recv_temp[package_max_size];

        tlib::cbuffer _send_buff;
        tlib::cbuffer _recv_buff;

        overlappedex _send_ex;
        overlappedex _recv_ex;

        api::iTcpSession * const _session;
        uint32 _socket;
    };
}

#endif //__tcpser_h__
