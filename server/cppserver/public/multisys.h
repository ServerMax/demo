#ifndef __multisys_h__
#define __multisys_h__

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <stdint.h>
#include <stdarg.h>

#ifdef WIN32
typedef __int8  int8;
typedef __int16 int16;
typedef __int32 int32;
typedef __int64 int64;

typedef unsigned __int8  uint8;
typedef unsigned __int16 uint16;
typedef unsigned __int32 uint32;
typedef unsigned __int64 uint64;

#else
typedef unsigned char uint8;
typedef unsigned short uint16;
typedef uint32_t uint32;
typedef uint64_t uint64;

typedef char int8;
typedef short int16;
typedef int32_t int32;
typedef int64_t int64;
#endif //WIN32

#pragma execution_character_set("utf-8")
#ifdef __cplusplus
extern "C" {
#endif 
#ifdef WIN32
    void sleep(int millisecond);
#endif //WIN32
    void _assertionfail(const char * file, int line, const char * funname, const char * debug);
#ifdef __cplusplus
};
#endif

#if defined _DEBUG

// void * operator new(size_t size, const char* file, const size_t line);
// void * operator new[](size_t size, const char* file, const size_t line);
// void operator delete (void * pointer);
// void operator delete[](void * pointer);
// void memory_trace();

#define tmalloc malloc
#define tfree free
#define tnew new //(__FILE__, __LINE__)
#define tdel delete
#define trace_memory //memory_trace();

#define tassert(p, format, ...) { \
    char debug[256] = {0}; \
    safesprintf(debug, sizeof(debug), format, ##__VA_ARGS__); \
    ((p) ? (void)0 : (void)_assertionfail(__FILE__, __LINE__, __FUNCTION__, debug)); \
}

#else
#define tmalloc malloc
#define tfree free
#define tnew new
#define tdel delete
#define trace_memory
#define tassert

#endif //defined _DEBUG

#define OUT
#define IN

#ifdef WIN32 
#define safesprintf sprintf_s
#define msleep(n) sleep(n)
#define atoi64 _atoi64
#define t_vsnprintf _vsnprintf
#define t_thread_id unsigned long long 
#else
#include <unistd.h>
#define safesprintf snprintf
#define msleep(n) usleep(n * 1000)
#define atoi64 atoll
#define t_vsnprintf vsnprintf
#define t_thread_id pthread_t
#endif

#endif //__multisys_h__
