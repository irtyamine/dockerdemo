ECHO OFF

ECHO running web and sql together

docker-compose build

docker-compose up

docker-compose rm -f