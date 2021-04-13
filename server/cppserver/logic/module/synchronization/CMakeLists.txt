#cmake file for project core
#author : max
#created : 2021-02-22 13:48:01

set(synchronization
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/header.h"
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/clientSession.h"
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/clientSession.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/synchronization.h"
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/synchronization.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/synchronization/main.cpp"
)

source_group(api FILES ${api})
source_group(common FILES ${common})
source_group(interface FILES ${interface})
source_group(public FILES ${public})
source_group(\\ FILES ${synchronization})

add_library(synchronization SHARED
    ${synchronization}
    ${api}
    ${public}
    ${interface}
    ${common}
)

set_property(TARGET synchronization PROPERTY FOLDER "game")
