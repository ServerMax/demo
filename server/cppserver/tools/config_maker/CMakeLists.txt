#cmake file for project core
#author:alax
#created:2015-05-12 15:07:04

INCLUDE_DIRECTORIES(
    "${PROJECT_SOURCE_DIR}/api"
    "${PROJECT_SOURCE_DIR}/public"
    "${PROJECT_SOURCE_DIR}/tools/config_maker")
    
SET(config_maker 
    "${PROJECT_SOURCE_DIR}/tools/config_maker/header.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/tenums.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/tstructs.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/ts/tsmaker.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/ts/tsmaker.cpp"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/csharp/csharpmaker.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/csharp/csharpmaker.cpp"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/cpp/cppmaker.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/cpp/cppmaker.cpp"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/jsonmaker.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/jsonmaker.cpp"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/xmlmaker.h"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/xmlmaker.cpp"
    "${PROJECT_SOURCE_DIR}/tools/config_maker/main.cpp"
)

SOURCE_GROUP(api FILES ${api})
SOURCE_GROUP(public FILES ${public})
SOURCE_GROUP(public\\tinyxml FILES ${tinyxml})
SOURCE_GROUP(\\ FILES ${config_maker})

ADD_EXECUTABLE(config_maker
    ${api}
    ${tinyxml}
    ${public}
    ${config_maker}
)

SET_PROPERTY(TARGET config_maker PROPERTY FOLDER "tools")
