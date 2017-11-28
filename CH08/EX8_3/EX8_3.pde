int xPos=200, yPos=200;
void setup() {
  size(400, 400);
  smooth();
}

void draw() {
  background(204); 
  if (keyPressed) {
    if (key == 'w') {
      yPos -= 5;
    }
    if (key == 's') {
      yPos += 5;
    }
    if (key == 'a') {
      xPos -= 5;
    }
    if (key == 'd') {
      xPos += 5;
    }
  }
  rect(xPos-25, yPos-25, 50, 50); 
  delay(100);
}