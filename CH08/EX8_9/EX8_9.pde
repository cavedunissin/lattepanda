import processing.serial.*;
import cc.arduino.*;
Arduino arduino;

color off = color(4, 79, 111);
color on = color(84, 145, 158);

void setup() {
  size(470, 200);
  println(Arduino.list());//顯示所有可用的序列埠號
  arduino = new Arduino(this, Arduino.list()[0], 57600);
  arduino.pinMode(13, Arduino.OUTPUT);  //設定D13腳位為輸出
}

void draw() {
  background(off);
  stroke(on);
  
  if( arduino.analogRead(0) > 800){  //根據心跳來點亮LED燈
    arduino.digitalWrite(13, Arduino.HIGH) ;  
  }
  fill(234, 102, 221);
  textSize(32);
  text(arduino.analogRead(2), 10, 30);  //將A2腳位，即溫度感測器值顯示於畫面
  delay(50);
}