from gtts import gTTS
tts = gTTS(text='Drizzle on Saturday and Tuesday, with temperatures rising to 26°C on Tuesday.', lang='zh-TW')
tts.save('weather.mp3')
