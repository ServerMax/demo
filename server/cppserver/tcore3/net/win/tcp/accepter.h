#ifndef __accepter_h__
#define __accepter_h__

#include "interface.h"

namespace tcore {
#define accept_temp_size 512

    class accepter : public iCompleter, public api::iAccepter {
    public:
        virtual ~accepter() {}

        static accepter * create(api::iTcpServer * server, const std::string & ip, const int32 port, const int32 ssize, const int32 rsize);

        virtual void onCompleter(overlappedex * ex, const eCompletion type, const int32 code, const int32 size);
        virtual void release();
        bool async_accept();

        api::iTcpServer * const _server;
        const int32 _ssize;
        const int32 _rsize;
        const oAddress _listen_addr;

    private:
        friend tlib::tpool<accepter>;
        accepter(api::iTcpServer * server, const std::string & ip, const int32 port, const int32 s_size, const int32 r_size);

    private:
        char _temp[accept_temp_size];

    private:
        uint32 _socket;
        sockaddr_in _addr;
        overlappedex _ex;
    };
}

#endif //__accepter_h__


