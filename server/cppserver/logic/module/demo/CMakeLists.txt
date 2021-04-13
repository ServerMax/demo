#cmake file for project core
#author : max
#created : 2021-04-13 19:03:26

set(demo
    "${PROJECT_SOURCE_DIR}/logic/module/demo/header.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/demo.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/demo.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/connecter.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/connecter.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/connecterManager.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/connecterManager.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/scene.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/scene.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/sceneManager.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/sceneManager.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/uuidManager.h"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/uuidManager.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/demo/main.cpp"
)

source_group(api FILES ${api})
source_group(common FILES ${common})
source_group(interface FILES ${interface})
source_group(public FILES ${public})
source_group(\\ FILES ${demo})

add_library(demo SHARED
    ${demo}
    ${api}
    ${public}
    ${interface}
    ${common}
)

set_property(TARGET demo PROPERTY FOLDER "demo")
