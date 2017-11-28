#define sensorPin A0

void setup() {
  Serial.begin(9600);    //Serial monitor
  Serial1.begin(9600);  //LattePanda對Arduino的序列通訊
}

void loop() {
  int Sensor = analogRead(sensorPin);
  Serial.println(Sensor);   //顯示A0腳位狀態
  Serial1.print('a');
  Serial1.print(String(Sensor).length());
  Serial1.print(Sensor);        
  //#11~#13為搭配標頭a、資料長度與資料本體
  //結合成一個封包之後發送給LattePanda
  delay(1000);
}
