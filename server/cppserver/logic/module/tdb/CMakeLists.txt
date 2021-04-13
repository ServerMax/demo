#cmake file for project core
#author : max
#created : 2021-03-16 11:14:25

set(tdb
    "${PROJECT_SOURCE_DIR}/logic/module/tdb/header.h"
    "${PROJECT_SOURCE_DIR}/logic/module/tdb/tdb.h"
    "${PROJECT_SOURCE_DIR}/logic/module/tdb/tdb.cpp"
    "${PROJECT_SOURCE_DIR}/logic/module/tdb/main.cpp"
)

source_group(api FILES ${api})
source_group(common FILES ${common})
source_group(interface FILES ${interface})
source_group(public FILES ${public})
source_group(\\ FILES ${tdb})

add_library(tdb SHARED
    ${tdb}
    ${api}
    ${public}
    ${interface}
    ${common}
)

TARGET_LINK_LIBRARIES(tdb
    ${libmysql_xapi}
)

set_property(TARGET tdb PROPERTY FOLDER "compment")
