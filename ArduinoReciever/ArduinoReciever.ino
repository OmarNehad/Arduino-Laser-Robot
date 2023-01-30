#include "Servo.h"
int Th1, Th2, tmp;
Servo M1, M2;
void setup() 
{
  // Sets up the BaudRate same as the one defined in the app
  Serial.begin(9600);

  // Sets up the laser.
  pinMode(4,OUTPUT);
  digitalWrite(4,0);
  Th1 = 0;
  Th2 = 0;
  M1.attach(2);
  M2.attach(3);

  // Sets the robot to the default position
  M1.write(90);
  M2.write(90);
  
}
void loop() 
{
  delay(200);

  // more than 2 bytes are sent from the app
  if(Serial.available()>=2)
  {
    
    Th1 = Serial.read();
    Th2 = Serial.read();
    M2.write(Th1);
    M2.write(Th2);
    
    // Turns on the laser.
    digitalWrite(4,HIGH);

    //while(Serial.available()) tmp = Serial.read();
    
    //Serial.print('1');
  }


}