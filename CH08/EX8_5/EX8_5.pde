import processing.serial.*;
import cc.arduino.*;  //匯入所需函式庫
Arduino arduino;    //宣告arduino物件

color off = color(4, 79, 111);    //定義顏色
color on = color(84, 145, 158);

void setup() {
  size(470, 280);
  println(Arduino.list());//顯示所有可用的序列埠號
  
  //一般來說，Arduino.list()[0]就能自動抓到您的Arduino
  //但如果不行的話，請將Arduino.list()[0]改為Arduino於
  //您電腦裝置管理員的序列埠號，例如"COM3"
  arduino = new Arduino(this, Arduino.list()[0], 57600);
  
  //將所有數位腳位設為輸入模式
  for (int i = 0; i <= 13; i++)
    arduino.pinMode(i, Arduino.INPUT);
}

void draw() {
  background(off);
  stroke(on);
  
  //根據腳位狀態決定是否填滿方格
  for (int i = 0; i <= 13; i++) {
    if (arduino.digitalRead(i) == Arduino.HIGH)//如為高電位
      fill(on);                            //填滿方格
    else
      fill(off);
      
    rect(420 - i * 30, 30, 20, 20);
  }

  //根據類比輸入腳位的數值大小來繪製圓圈
  noFill();
  for (int i = 0; i <= 5; i++) {
    ellipse(280 + i * 30, 240, 
          arduino.analogRead(i) / 16, arduino.analogRead(i) / 16);
  }
}