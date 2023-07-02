#!/bin/bash

find . -name docker-compose.yaml -or -name docker-compose.yml -exec sudo docker-compose -f '{}' stop \;
