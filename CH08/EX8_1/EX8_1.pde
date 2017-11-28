size(400, 400);
smooth();
background(255);
noStroke();

int xPos = 40, yPos = 20; 
int i, j;
int r, g, b;
for (j=0; j<5; j++) {
  for (i=0; i<5; i++) {
    r = int(random(255));
    g = int(random(255));
    b = int(random(255));
    fill(r, g, b);
    ellipse(xPos, yPos, 20, 20);
    xPos += 30;
    print(r); 
    print(", ");
    print(g); 
    print(", ");
    println(b);
  }
  xPos = 40;
  yPos += 40;
}