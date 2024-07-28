#include <Wire.h>
#define I2C_SLAVE_ADDRESS 4
// Reassign HC-SR04 pins to free up I2C pins
#define TRIGGER_PIN 12  // D6 (GPIO12)
#define ECHO_PIN 13     // D7 (GPIO13)
// Maximum distance we want to ping for (in centimeters).
#define MAX_DISTANCE 400
#define MIN_DISTANCE 30
#define BUZZER_PIN 14  // D5 (GPIO14)
// I2C Pins
int SCL_pin = 5; // D1 (GPIO5)
int SDA_pin = 4; // D2 (GPIO4)

void setup() {
  Serial.begin(115200);
  pinMode(TRIGGER_PIN, OUTPUT);
  pinMode(ECHO_PIN, INPUT);
  pinMode(BUZZER_PIN, OUTPUT);
  // Initialize I2C communication as Slave
  pinMode(SCL_pin, OUTPUT);
  pinMode(SDA_pin, OUTPUT);
  digitalWrite(SDA_pin, LOW);
  digitalWrite(SCL_pin, LOW);
  Wire.begin(SDA_pin, SCL_pin);
  Wire.onReceive(receiveEvent);
}

void loop() {
  // Ping sensor
  digitalWrite(TRIGGER_PIN, LOW);
  delayMicroseconds(2);
  digitalWrite(TRIGGER_PIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIGGER_PIN, LOW);
  float duration = pulseIn(ECHO_PIN, HIGH);
  float distance = duration * 0.034 / 2;

  if (distance < MIN_DISTANCE) {
    tone(BUZZER_PIN, 1000, 200);
  } else {
    noTone(BUZZER_PIN);
  }

  Serial.print("Distance = ");
  Serial.print(distance);
  Serial.println(" cm");
  String distString = "Dist: " + String(distance);
  Wire.beginTransmission(I2C_SLAVE_ADDRESS); // transmit to device #4
  Wire.write(distString.c_str()); // send the distance string as a C-style string
  Wire.endTransmission();
  delay(500);
}
// Function to be called when data is received
void receiveEvent(int howMany) {
  while (Wire.available()) {
    char c = Wire.read();
    Serial.print(c);
  }
  Serial.println();
}