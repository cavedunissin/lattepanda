void setup() {
  Serial.begin(9600);
}

void loop() {
  int sensorValue = analogRead(A0); //讀取A0腳位狀態
  Serial.println(sensorValue);
  delay(1);        //每秒更新1000次
}