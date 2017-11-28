import processing.serial.*;
import cc.arduino.*;
Arduino arduino;

void setup() {
  size(512, 200);

  // Prints out the available serial ports.
  println(Arduino.list());
  
  // Modify this line, by changing the "0" to the index of the serial
  // port corresponding to your Arduino board (as it appears in the list
  // printed by the line above).
  arduino = new Arduino(this, Arduino.list()[0], 57600);
}

void draw() {
  background(constrain(mouseX / 2, 0, 255));
  //根據滑鼠的X座標來決定背景顏色的紅色強度
  //以LattePanda的Arduino晶片來說
  //支援PWM腳位的數位腳位3、5、6、9、10與11
  
  int pin9 = constrain(mouseX / 2, 0, 255);
  int pin11 = constrain(255 - mouseX / 2, 0, 255);
  arduino.analogWrite(9, pin9);
  arduino.analogWrite(11, constrain(255 - mouseX / 2, 0, 255));
  fill(234, 102, 221);
  textSize(32);
  text(pin9, 10, 30);
  text(pin11, 10, 70);
}