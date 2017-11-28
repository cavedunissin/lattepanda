int width = 600;
int height = 480;
float radius = 150;  //圓圈基本半徑
int x, y, nx, ny;    //座標
int delay = 16;    //延遲參數，數值愈大延遲效果愈明顯
int r = (int)random(255);
int g = (int)random(255);
int b = (int)random(255);   //隨機決定背景顏色
int rc = r - (int)random(25);
int gc = g - (int)random(25);
int bc = b - (int)random(25); //隨機決定球的顏色

void setup() {
  size(width, height);
  strokeWeight(width/20);
  x = width/2;
  y = height/2;
  nx = x;
  ny = y;
}

void draw() {
  background(r, g, b); //清除背景
  radius = radius + sin( frameCount / 4); //更新半徑
  //追蹤圓圈到新終點的路徑
  x+=(nx-x)/delay;
  y+=(ny-y)/delay;

  //根據上述資訊畫圓
  fill(rc, gc, bc);
  stroke(255);
  ellipse(x, y, radius, radius);
}

void mouseMoved() {
  nx = mouseX;
  ny = mouseY;
}

void mouseDragged() {
  mouseMoved();
}

void mousePressed() {
  mouseMoved();
}