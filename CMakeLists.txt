cmake_minimum_required (VERSION 3.6)
project(election-bot)

if(NOT SLEEPY_DISCORD_CMAKE)
	add_subdirectory(sleepy-discord)
endif()

add_executable(election
	main.cpp
)

target_link_libraries(election
	sleepy-discord
)
