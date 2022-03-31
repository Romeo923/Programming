//
// Copyright 2015 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

// FirebaseDemo_ESP8266 is a sample that demo the different functions
// of the FirebaseArduino API.

#include <ESP8266WiFi.h>
#include <FirebaseArduino.h>

// Set these to run example.
#define FIREBASE_HOST "ore-locks-default-rtdb.firebaseio.com/"
#define FIREBASE_AUTH "9l5TGYhBTqvX4Npcc1J2Qypj6WCMqj6uHeU2RLSc"
#define WIFI_SSID "Romeo"
#define WIFI_PASSWORD "King12345"

const int RELAY_PIN = 3;

const String LOCK_REQUEST_PATH = "Account_id/Primary_Keys/Building_id/Door_id/lock_request";
const String LOCK_STATUS_PATH = "Account_id/Primary_Keys/Building_id/Door_id/locked";

void setup() {
  Serial.begin(9600);
  pinMode(RELAY_PIN, OUTPUT);

  // connect to wifi.
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(500);
  }
  Serial.println();
  Serial.print("connected: ");
  Serial.println(WiFi.localIP());
  
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
}

void loop() {

  
  bool lock_request = Firebase.getInt(LOCK_REQUEST_PATH);

  if(lock_request == 1){ //Check if door must be locked
    digitalWrite(RELAY_PIN, HIGH); //locks door
    Firebase.setInt(LOCK_REQUEST_PATH, 0);
    Firebase.setBool(LOCK_STATUS_PATH, true);
    
  }else if(lock_request == 2){ //Check if door must be unlocked
    digitalWrite(RELAY_PIN, LOW); //unlocks door
    Firebase.setInt(LOCK_REQUEST_PATH, 0);
    Firebase.setBool(LOCK_STATUS_PATH, false);
  }
  
  delay(1000);
  
}
