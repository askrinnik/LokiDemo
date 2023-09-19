SET IMAGE-NAME=grafana/loki:latest
SET CONTAINER-NAME=LokiServer

docker rm -f %CONTAINER-NAME%

docker pull %IMAGE-NAME%

docker run ^
--name=%CONTAINER-NAME% ^
-p 3100:3100 ^
-p 9095:9095 ^
-h logs ^
-v "loki:/loki" ^
%IMAGE-NAME%

pause