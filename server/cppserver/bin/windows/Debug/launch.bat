cd %~dp0
echo off;
echo "kill old proc..."
taskkill /im tcore3.exe
pause
echo "launche string...."

start "master" tcore3 --name=master --env=env --console_ip=127.0.0.1 --console_port=8888
start "center" tcore3 --name=center --noder_ip=127.0.0.1 --noder_port=9100 --noder_area=1 --allarea --env=env
start "slb" tcore3 --name=slb --noder_ip=127.0.0.1 --noder_port=9200 --noder_area=1 --slb_port=10000 --max_ssize=64 --max_rsize=8 --env=env
start "gate" tcore3 --name=gate --noder_ip=127.0.0.1 --noder_port=9300 --noder_area=1 --door_ip=127.0.0.1 --door_port=28001 --max_ssize=64 --max_rsize=8 --env=env
start "gate" tcore3 --name=gate --noder_ip=127.0.0.1 --noder_port=9301 --noder_area=1 --door_ip=127.0.0.1 --door_port=28002 --max_ssize=64 --max_rsize=8 --env=env
start "game" tcore3 --name=game --noder_ip=127.0.0.1 --noder_port=9400 --noder_area=1 --allarea --env=env
start "cache" tcore3 --name=cache --noder_ip=127.0.0.1 --noder_port=9500 --noder_area=1 --allarea --env=env --cache_id=0
start "cache" tcore3 --name=cache --noder_ip=127.0.0.1 --noder_port=9501 --noder_area=1 --allarea --env=env --cache_id=1