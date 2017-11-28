import processing.serial.*;
import cc.arduino.*;
Arduino arduino;

color off = color(4, 79, 111);
color on = color(84, 145, 158);

int[] values = { Arduino.LOW, Arduino.LOW, Arduino.LOW, Arduino.LOW,
 Arduino.LOW, Arduino.LOW, Arduino.LOW, Arduino.LOW, Arduino.LOW,
 Arduino.LOW, Arduino.LOW, Arduino.LOW, Arduino.LOW, Arduino.LOW };

void setup() {
  size(470, 200);
  println(Arduino.list());//顯示所有可用的序列埠號
  arduino = new Arduino(this, Arduino.list()[0], 57600);

  for (int i = 0; i <= 13; i++)
    arduino.pinMode(i, Arduino.OUTPUT);  //設定所有腳位為輸出
}

void draw() {
  background(off);
  stroke(on);
  
  for (int i = 0; i <= 13; i++) {   
  //根據Arduino腳位狀態決定方格是否填滿
    if (values[i] == Arduino.HIGH)  
      fill(on);
    else
      fill(off);
      
    rect(420 - i * 30, 30, 20, 20);
  }
}

void mousePressed()
{
  int pin = (450 - mouseX) / 30;
  //如果某個方格被點選，則切換對應腳位狀態
  if (values[pin] == Arduino.LOW) {
    arduino.digitalWrite(pin, Arduino.HIGH);
    values[pin] = Arduino.HIGH;
  } else {
    arduino.digitalWrite(pin, Arduino.LOW);
    values[pin] = Arduino.LOW;
  }
}