#ifndef __NavMeshHandle_h__
#define __NavMeshHandle_h__

#include "iNavigation.h"

#include "header.h"
#include "DetourNavMeshBuilder.h"
#include "DetourNavMeshQuery.h"
#include "DetourCommon.h"
#include "DetourNavMesh.h"


#pragma pack(push, 1)
struct NavMeshSetHeader {
    int32 version;
    int32 tileCount;
    dtNavMeshParams params;
};

struct NavMeshTileHeader {
    dtTileRef tileRef;
    int32 dataSize;
};
#pragma pack(pop)

class navmesh : public iNavmesh {
public:
    static const int32 MAX_POLYS = 256;
    static const int32 NAV_ERROR_NEARESTPOLY = -2;

    static const long RCN_NAVMESH_VERSION = 1;
    static const int32 INVALID_NAVMESH_POLYREF = 0;
public:
    navmesh();
    virtual ~navmesh();

    virtual int32 findStraightPath(int32 layer, const geometry::vector3 & start, const geometry::vector3 & end, std::vector<geometry::vector3> & paths) const;
    virtual int32 raycast(int32 layer, const geometry::vector3 & start, const geometry::vector3 & end, geometry::vector3 & hit) const;
    virtual bool check(int32 layer, const geometry::vector3 & point) const;
    virtual bool findnearPoint(const geometry::vector3 & center, geometry::vector3 & target, const float radius) const;

    static navmesh * create(std::string name);
    
private:
    std::vector<dtNavMesh*> _navmesh_layers;
    std::vector<dtNavMeshQuery*> _navmeshQuery_layers;

    dtPolyRef _polys[MAX_POLYS];
};

#endif // __NavMeshHandle_h__

