#include <Servo.h>
int position = 0;
Servo myservo1;
Servo myservo2;
Servo myservo3;
Servo myservo4;
int servo1=30;
int servo2=30;
int servo3=30;
int servo4=30;
int incomingByte = 0;
int speed =5;
void setup() {
  Serial.begin(9600);
  myservo1.attach(9);
 myservo2.attach(10);
  myservo3.attach(11);
   myservo4.attach(12);
      myservo1.write(90);
myservo2.write(90);
myservo3.write(90);
myservo4.write(90);

}

void loop() {
   if (Serial.available() > 0) {
     incomingByte = Serial.read();
                switch (incomingByte)
                {
                  case 65:
                servo1+=speed;
                 myservo1.write(servo1);
                  break;
                  case 66:
                servo1-=speed;
                  myservo1.write(servo1);
                  break;
                  case 67:
                servo2+=speed;
                  myservo2.write(servo2);
                  break;
                  case 68:
                servo2-=speed;
                  myservo2.write(servo2);
                  break;
                  case 69:
                servo3+=speed;
                  myservo3.write(servo3);
                  break;
                  case 70:
                servo3-=speed;
                  myservo3.write(servo3);
                  break;
                  case 71:
                servo4+=speed;
                  myservo4.write(servo4);
                  break;
                 case 72:
                servo4-=speed;
                  myservo4.write(servo4);
                  break;
                }
   }
delay(50);
}
