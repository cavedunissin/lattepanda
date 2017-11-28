# This is a sample of weather bot written in python

## Preparation

The following installation steps is for windows, 
for posix users, 
it's recomended to use your system package manager.


1. Install python3 https://www.python.org/downloads/windows/

Remember to check the option to add the python system variable during the installation.

![](pic/python.png)

2. Launch command line prompt

Press shortcut win+R and type in __cmd__ to launch command line prompt, 
it's recommended to use powershell for windows users, 
just replace __cmd__ with __powershell__.

![](pic/powershell.png)



3. Install python package

```sh
pip install SpeechRecognition pyaudio python-forecastio gtts
```

![](pic/powershell-2.png)

4. Download this project from github

https://github.com/YuanYouYuan/weather-bot

![](pic/git.png)


5. Download mpv player, if you want to use windows media player, 
you can replace the player location in the code with the new location.


Download mpv https://mpv.srsfckn.biz/

![](pic/mpv.png)

Download 7z http://www.developershome.com/7-zip/ , if you can unzip the 7zip file.

![](pic/7z.png)

Finally move the mpv.exe into this project folder.

![](pic/mpv-2.png)

![](pic/mpv-3.png)



6. Execute the following code

open the folder and open the weather-test.py with editor(ex. python IDLE)

![](pic/IDLE.png)

Edit the following code, replace the api key with your own weather api key got from this website.
https://darksky.net/dev/

![](pic/darksky.png)

Sign up a new account and get an api key.

![](pic/darksky-2.png)


```sh

# This version is for windows, and there must be a mpv application in this work directory

import forecastio
from gtts import gTTS
import subprocess

api_key = 'Enter your api key'

# the following coordinate is Taipei/Taiwan
lat = 25.0391667
lng =  121.525
lang = 'zh-TW'
file_name = 'weather.mp3'
player = './mpv'

forecast = forecastio.load_forecast(api_key, lat, lng)

by_hour = forecast.hourly()

for data in by_hour.data:
    text = '在' + str(data.time) + '氣溫是' +  str(data.temperature) + '度西'
    print(text)
    tts = gTTS(text, lang)
    tts.save(file_name)
    subprocess.call([player, file_name])
    

```


## Demo

![](pic/demo.png)

https://www.youtube.com/watch?v=j89Ui26aIGs
