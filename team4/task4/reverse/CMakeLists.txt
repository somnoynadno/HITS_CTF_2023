cmake_minimum_required(VERSION 3.0)

project(reverse)
# FILE(GLOB MyCSources cryptopp/*.cpp)

add_executable(reverse main.cpp)

install(TARGETS reverse RUNTIME DESTINATION bin)
