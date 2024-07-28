#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>
#include <Wire.h>
// Reassign HC-SR04 pins to free up I2C pins
#define TRIGGER_PIN 12  // D6 (GPIO12)
#define ECHO_PIN 13     // D7 (GPIO13)
#define BUZZER_PIN 15   // D5 (GPIO14)
// I2C Slave address
#define I2C_SLAVE_ADDRESS 4
#define I2C_MASTER_ADDRESS 5
// Threshold distance for activating the buzzer (in cm)
const float MIN_DISTANCE = 5.0; // Example threshold, adjust as needed
// SSID and Password for the ESP8266 AP network
const char* ssid = "Yakha2024";       // Enter SSID here
const char* password = "Yakha2024";   // Enter Password here
// I2C Pins
int SCL_pin = 5;  // D1 (GPIO5)
int SDA_pin = 4;  // D2 (GPIO4)
// Variables to hold sensor data
float temperature, humidity, pressure, altitude;
float distance = 0.0;  // Initialize distance variable
ESP8266WebServer server(80);
void setup() {
  pinMode(TRIGGER_PIN, OUTPUT);
  pinMode(ECHO_PIN, INPUT);
  pinMode(BUZZER_PIN, OUTPUT);
  // Initialize I2C communication as Slave
  Wire.begin(I2C_SLAVE_ADDRESS);
  Wire.onReceive(receiveEvent);
  Serial.begin(115200);
  Serial.println();
  Serial.print("Connecting to ");
  Serial.println(ssid);
  WiFi.begin(ssid, password);
  while (WiFi.status() != WL_CONNECTED) {
    delay(1000);
    Serial.print(".");
  }
  Serial.println("");
  Serial.println("WiFi connected..!");
  Serial.print("Got IP: ");
  Serial.println(WiFi.localIP());
  server.on("/", handle_OnConnect);
  server.onNotFound(handle_NotFound);
  server.begin();
  Serial.println("HTTP server started");
}
void loop() {
  // Ultrasonic sensor measurement
  digitalWrite(TRIGGER_PIN, LOW);
  delayMicroseconds(2);
  digitalWrite(TRIGGER_PIN, HIGH);
  delayMicroseconds(10);
  digitalWrite(TRIGGER_PIN, LOW);
  float duration = pulseIn(ECHO_PIN, HIGH);
  distance = duration * 0.034 / 2;
  // Check if distance is below threshold and activate buzzer
  if (distance < MIN_DISTANCE) {
    tone(BUZZER_PIN, 1000, 200);
  } else {
    noTone(BUZZER_PIN);
  }
  // Read temperature, humidity, pressure, and altitude from master Arduino via I2C
 // Wire.requestFrom(I2C_MASTER_ADDRESS, sizeof(float) * 4); // Request 4 floats from master
  Wire.requestFrom(I2C_MASTER_ADDRESS, sizeof(char) * 1);
//  while (Wire.available() < sizeof(float) * 4); // Wait for data to arrive
  while (Wire.available() < sizeof(char) * 1); // Wait for data to arrive
 
  Wire.readBytes((char *)&temperature, sizeof(float));
  Wire.readBytes((char *)&humidity, sizeof(float));
  Wire.readBytes((char *)&pressure, sizeof(float));
  Wire.readBytes((char *)&altitude, sizeof(float));
  // Send HTML page with sensor data to client
  String html = SendHTML(temperature, humidity, pressure, altitude, distance);
  server.send(200, "text/html", html);
  delay(500); // Delay for stability
}
String SendHTML(float temperature, float humidity, float pressure, float altitude, float distance) {
  String ptr = "<!DOCTYPE html>";
  ptr += "<html>";
  ptr += "<head>";
  ptr += "<title>ESP8266 Weather Station</title>";
  ptr += "<meta name='viewport' content='width=device-width, initial-scale=1.0'>";
  ptr += "<link href='https://fonts.googleapis.com/css?family=Open+Sans:300,400,600' rel='stylesheet'>";
  ptr += "<style>";
  ptr += "html { font-family: 'Open Sans', sans-serif; display: block; margin: 0px auto; text-align: center; color: #444444;}";
  ptr += "body { margin: 0px; }";
  ptr += "h1 { margin: 50px auto 30px; }";
  ptr += ".side-by-side { display: table-cell; vertical-align: middle; position: relative; }";
  ptr += ".text { font-weight: 600; font-size: 19px; width: 200px; }";
  ptr += ".reading { font-weight: 300; font-size: 50px; padding-right: 25px; }";
  ptr += ".temperature .reading { color: #F29C1F; }";
  ptr += ".humidity .reading { color: #3B97D3; }";
  ptr += ".pressure .reading { color: #26B99A; }";
  ptr += ".altitude .reading { color: #955BA5; }";
  ptr += ".distance .reading { color: #FF9800; }";  // Color for distance reading
  ptr += ".superscript { font-size: 17px; font-weight: 600; position: absolute; top: 10px; }";
  ptr += ".data { padding: 10px; }";
  ptr += ".container { display: table; margin: 0 auto; }";
  ptr += ".icon { width: 65px }";
  ptr += "</style>";
  ptr += "</head>";
  ptr += "<body>";
  ptr += "<h1>ESP8266 Weather Station</h1>";
  ptr += "<div class='container'>";
  ptr += "<div class='data temperature'>";
  ptr += "<div class='side-by-side icon'>";
  ptr += "<svg enable-background='new 0 0 19.438 54.003' height='54.003px' id='Layer_1' version='1.1' viewBox='0 0 19.438 54.003' width='19.438px' x='0px' xml:space='preserve' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' y='0px'><g><path d='M11.976,8.82v-2h4.084V6.063C16.06,2.715,13.345,0,9.996,0H9.313C5.965,0,3.252,2.715,3.252,6.063v30.982 C1.261,38.825,0,41.403,0,44.286c0,5.367,4.351,9.718,9.719,9.718c5.368,0,9.719-4.351,9.719-9.718 c0-2.943-1.312-5.574-3.378-7.355V18.436h-3.914v-2h3.914v-2.808h-4.084v-2h4.084V8.82H11.976z M15.302,44.833 c0,3.083-2.5,5.583-5.583,5.583s-5.583-2.5-5.583-5.583c0-2.279,1.368-4.236,3.326-5.104V24.257C7.462,23.01,8.472,22,9.719,22 s2.257,1.01,2.257,2.257V39.73C13.934,40.597,15.302,42.554,15.302,44.833z' fill='#F29C21'/></g></svg>";
  ptr += "</div>";
  ptr += "<div class='side-by-side text'>Temperature</div>";
  ptr += "<div class='side-by-side reading'>" + String((int)temperature) + "<span class='superscript'>&deg;C</span></div>";
  ptr += "</div>";
  ptr += "<div class='data humidity'>";
  ptr += "<div class='side-by-side icon'>";
  ptr += "<svg enable-background='new 0 0 29.235 40.64' height='40.64px' id='Layer_1' version='1.1' viewBox='0 0 29.235 40.64' width='29.235px' x='0px' xml:space='preserve' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' y='0px'><path d='M14.618,0C14.618,0,0,17.95,0,26.022C0,34.096,6.544,40.64,14.618,40.64s14.617-6.544,14.617-14.617 C29.235,17.95,14.618,0,14.618,0z M13.667,37.135c-5.604,0-10.162-4.56-10.162-10.162c0-0.787,0.638-1.425,1.425-1.425 c0.787,0,1.425,0.638,1.425,1.425c0,4.031,3.28,7.312,7.311,7.312c4.031,0,7.312-3.28,7.312-7.312c0-0.787,0.638-1.425,1.425-1.425 c0.787,0,1.425,0.638,1.425,1.425C23.83,32.575,19.271,37.135,13.667,37.135z' fill='#3C97D3'/></svg>";
  ptr += "</div>";
  ptr += "<div class='side-by-side text'>Humidity</div>";
  ptr += "<div class='side-by-side reading'>" + String((int)humidity) + "<span class='superscript'>%</span></div>";
  ptr += "</div>";
  ptr += "<div class='data pressure'>";
  ptr += "<div class='side-by-side icon'>";
  ptr += "<svg enable-background='new 0 0 40.542 40.541' height='40.541px' id='Layer_1' version='1.1' viewBox='0 0 40.542 40.541' width='40.542px' x='0px' xml:space='preserve' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' y='0px'><g><path d='M34.313,20.271c0-0.552,0.447-1,1-1h5.178c-0.236-4.841-2.163-9.228-5.214-12.593l-3.425,3.426 c-0.391,0.391-1.023,0.391-1.414,0L27.69,7.455c-0.391-0.391-0.391-1.023,0-1.414l3.424-3.425C27.749,0.566,23.362,2.639,18.521,2.874 v5.178c0,0.553-0.447,1-1,1h-3.125c-0.552,0-1-0.447-1-1V2.874c-4.841,0.235-9.228,2.163-12.593,5.214l3.426,3.425 c0.391,0.391,0.391,1.023,0,1.414L2.463,16.62c-0.391,0.391-1.023,0.391-1.414,0L0.317,14.888c-2.262,3.37-3.348,7.367-3.336,11.383 l5.178,0c0.553,0,1,0.447,1,1v3.125c0,0.553-0.447,1-1,1l-5.178,0.001c0.236,4.841,2.163,9.228,5.214,12.592l-3.426-3.424 c-0.391-0.391-0.391-1.023,0-1.414l1.731-1.731c0.391-0.391,1.023-0.391,1.414,0l3.425,3.426c2.262-3.37,3.348-7.367,3.336-11.383 h-5.178c-0.553,0-1-0.447-1-1V20.271z M20.271,28.271c-4.418,0-8-3.582-8-8c0-4.418,3.582-8,8-8s8,3.582,8,8 C28.271,24.689,24.689,28.271,20.271,28.271z' fill='#26B99A'/></g></svg>";
  ptr += "</div>";
  ptr += "<div class='side-by-side text'>Pressure</div>";
  ptr += "<div class='side-by-side reading'>" + String(pressure) + "<span class='superscript'>hPa</span></div>";
  ptr += "</div>";
  ptr += "<div class='data altitude'>";
  ptr += "<div class='side-by-side icon'>";
  ptr += "<svg enable-background='new 0 0 48.226 48.226' height='48.226px' id='Layer_1' version='1.1' viewBox='0 0 48.226 48.226' width='48.226px' x='0px' xml:space='preserve' xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink' y='0px'><g><path d='M48.226,45.138H0l24.113-42.05L48.226,45.138z M42.548,42.05L24.113,9.776L5.679,42.05H42.548z' fill='#955BA5'/></g></svg>";
  ptr += "</div>";
  ptr += "<div class='side-by-side text'>Altitude</div>";
  ptr += "<div class='side-by-side reading'>" + String(altitude) + "<span class='superscript'>m</span></div>";
  ptr += "</div>";
  ptr += "<div class='data distance'>";
  ptr += "<div class='side-by-side icon'>";
  ptr += "<svg enable-background='new 0 0 24 24' height='24px' id='Layer_1' version='1.1' viewBox='0 0 24 24' width='24px' x='0px' y='0px'><path d='M22,12c0-5.516-4.485-10-10-10S2,6.484,2,12s4.485,10,10,10S22,17.516,22,12z M5,12c0-3.859,3.141-7,7-7s7,3.141,7,7 s-3.141,7-7,7S5,15.859,5,12z M15.412,7.588l-4.82,4.819l4.82,4.819c0.391,0.391,0.391,1.023,0,1.414l-1.413,1.413 c-0.391,0.391-1.023,0.391-1.414,0L7.947,12l5.648-5.648c0.391-0.391,1.023-0.391,1.414,0l1.413,1.413 C15.802,6.565,15.802,7.197,15.412,7.588z' fill='#FF9800'/></svg>";
  ptr += "</div>";
  ptr += "<div class='side-by-side text'>Distance</div>";
  ptr += "<div class='side-by-side reading'>" + String(distance) + "<span class='superscript'>cm</span></div>";
  ptr += "</div>";
  ptr += "</div>";
  ptr += "<script>";
  ptr += "setInterval(function() {";
  ptr += "var xhttp = new XMLHttpRequest();";
  ptr += "xhttp.onreadystatechange = function() {";
  ptr += "if (this.readyState == 4 && this.status == 200) {";
  ptr += "document.body.innerHTML = this.responseText;";
  ptr += "}";
  ptr += "};";
  ptr += "xhttp.open('GET', '/', true);";
  ptr += "xhttp.send();";
  ptr += "}, 5000);";  // Update the data every 5 seconds
  ptr += "</script>";
  ptr += "</body>";
  ptr += "</html>";
  return ptr;
}
void handle_OnConnect() {
  temperature = 0;
  humidity = 0;
  pressure = 0;
  altitude = 0;
  distance = 0;
  String html = SendHTML(temperature, humidity, pressure, altitude, distance);
  server.send(200, "text/html", html);
}
void handle_NotFound() {
  server.send(404, "text/plain", "Not found");
}

void receiveEvent(int bytes) {
  // This is not used in the ESP8266 (Slave)
}

/*void receiveEvent(int howMany) {
  while (Wire.available()) {
    char c = Wire.read();
    Serial.print(c);
  }
  Serial.println();
}*/
