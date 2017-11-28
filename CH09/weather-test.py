import speech_recognition as sr
import forecastio
from gtts import gTTS
import subprocess

api_key = 'Enter your api key'
lat = 25.0391667
lng =  121.525
lang = 'zh-TW'
file_name = 'weather.mp3'
player = 'mpv'

forecast = forecastio.load_forecast(api_key, lat, lng)
r = sr.Recognizer()

def speak(text):
    print(text)
    tts = gTTS(text, lang)
    tts.save(file_name)
    subprocess.call([player, file_name])


while True:
    with sr.Microphone() as source:
        print("Say something!")
        audio = r.listen(source)
        cmd = r.recognize_google(audio, language = lang)
        print(cmd)

    if cmd == '你好':
        speak('你好啊，我是拿鐵熊貓機器人，你可以問我有關天氣的問題喔!')

    elif cmd == '氣溫預報':
        by_hour = forecast.hourly()
        for data in by_hour.data:
            speak('在' + str(data.time) + '氣溫是' +  str(data.temperature) + '度西')
    else:
        speak("對不起，我不懂你在說什麼")
