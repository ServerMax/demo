#cmake file for project core
#author:alax
#created:2015-05-12 15:07:04

INCLUDE_DIRECTORIES(
    "${PROJECT_SOURCE_DIR}/api"
    "${PROJECT_SOURCE_DIR}/public"
    "${PROJECT_SOURCE_DIR}/tools/file_compare")
    
SET(file_compare 
    "${PROJECT_SOURCE_DIR}/tools/file_compare/main.cpp"
)

SOURCE_GROUP(api FILES ${api})
SOURCE_GROUP(public FILES ${public})
SOURCE_GROUP(public\\tinyxml FILES ${tinyxml})
SOURCE_GROUP(\\ FILES ${file_compare})

ADD_EXECUTABLE(file_compare
    ${api}
    ${tinyxml}
    ${public}
    ${file_compare}
)

SET_PROPERTY(TARGET file_compare PROPERTY FOLDER "tools")
