#ifndef __rediser_h__
#define __rediser_h__

#include "header.h"

namespace tcore {
    class redisTransaction;

    enum eOptType {
        async_set,
        async_get,
        async_del,
        async_transaction,

        unknown_type
    };

    struct oOpt {
        uint32 _id;
        std::string _word;
        eOptType _type;
        void * _data;
        uint32 _len;
        iContext _context;
        iRedisCompleter * _completer;
        fRedisCall _caller;
        redisTransaction* _transaction;
        fRdsTransactionCall _rdsTransCall;

        oOpt() : _id(-1), _word(""), _type(unknown_type), _data(nullptr), _len(0), _context(-1), _completer(nullptr), _caller(nullptr), _transaction(nullptr), _rdsTransCall(nullptr) {}
        oOpt(const uint32 id, const std::string & word, const eOptType type, void * data, const uint32 len, const iContext context, 
            iRedisCompleter * completer, fRedisCall caller, redisTransaction* transaction, fRdsTransactionCall rdstranscall)
            : _id(id), _word(word), _type(type), _data(data), _len(len), _context(context), 
            _completer(completer), _caller(caller), _transaction(transaction), _rdsTransCall(rdstranscall){}
    };

    struct oResult {
        oOpt * _opt;
        redisReply * _redisReply;
        tlib::cargs _results;

        oResult() : _opt(nullptr), _redisReply(nullptr) {}
        oResult(oOpt * opt, redisReply * redisReply, const tlib::cargs & results) : _opt(opt), _redisReply(redisReply), _results(results) {}
    };

    class rediser : public iRediser, public api::iTimer, public tlib::cthread, public api::iLooper {
    public:
        virtual ~rediser();
        rediser(const char * ip, const int32 port, const char * passwd);

        virtual void completerSet(const uint32 id, const char * key, iRedisCompleter * completer, const void * data, const uint32 len, bool sync, const iContext context);
        virtual void completerGet(const uint32 id, const char * key, iRedisCompleter * completer, bool sync, const iContext context);
        virtual void completerDel(const uint32 id, const char * key, iRedisCompleter * completer, bool sync, const iContext context);

        virtual void callerSet(const uint32 id, const char * key, const fRedisCall & call, const void * data, const uint32 len, bool sync, const iContext context);
        virtual void callerGet(const uint32 id, const char * key, const fRedisCall & call, bool sync, const iContext context);
        virtual void callerDel(const uint32 id, const char* key, const fRedisCall & call, bool sync, const iContext context);
        virtual iRedisTransaction* createTransation();

        void doTransation(redisTransaction * tras, const uint32 id, const fRdsTransactionCall& call, bool sync, const iContext context);

        virtual const oAddress * getAddrInfo();

        virtual void onStart(iCore * core, const int32 id, const iContext & context, const int64 tick) {}
        virtual void onTimer(iCore * core, const int32 id, const iContext & context, const int64 tick);
        virtual void onEnd(iCore * core, const int32 id, const iContext & context, bool nonviolent, const int64 tick) {}
        virtual void onPause(iCore * core, const int32 id, const iContext & context, const int64 tick) {}
        virtual void onResume(iCore * core, const int32 id, const iContext & context, const int64 tick) {}

        virtual void terminate();
        virtual void run();

        virtual void deal();

        bool tryConnect();
        void connect();

        inline int getOptQueueSize() {
            return _opt_queue.count();
        }

        const oAddress _addr;
        const std::string _passwd;
    private:
        void checkContext();

    private:
        redisContext * _context;
        tlib::spinlock _lock;
        tlib::tqueue<oOpt *> _opt_queue;
        tlib::tqueue<oResult *> _res_queue;
    };
}

#endif //__rediser_h__
