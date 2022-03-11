
/**
 * Created by K. Suwatchai (Mobizt)
 * 
 * Email: k_suwatchai@hotmail.com
 * 
 * Github: https://github.com/mobizt/Firebase-ESP-Client
 * 
 * Copyright (c) 2022 mobizt
 *
*/

#if defined(ESP32)
#include <WiFi.h>
#elif defined(ESP8266)
#include <ESP8266WiFi.h>
#endif

#include <Firebase_ESP_Client.h>

//Provide the token generation process info.
#include <addons/TokenHelper.h>

//Provide the RTDB payload printing info and other helper functions.
#include <addons/RTDBHelper.h>

/* 1. Define the WiFi credentials */
#define HOME_WIFI "E81EA4"
#define HOME_WIFI_PASSWORD "20167417"

#define HS_WIFI "Romeo"
#define HS_WIFI_PASSWORD "King12345"

#define WIFI_SSID HOME_WIFI
#define WIFI_PASSWORD HOME_WIFI_PASSWORD

//For the following credentials, see examples/Authentications/SignInAsUser/EmailPassword/EmailPassword.ino

/* 2. Define the API Key */
#define TESTDB_API_KEY "AIzaSyDqDQXoymPfJNQ-Smz5o5pxIhgNDYCh5IE"

#define ORE_RTDB_API_KEY "AIzaSyA8LEQ25L0fQSlr-lMFR-d2hGI78Oes7XI"

#define API_KEY ORE_RTDB_API_KEY

/* 3. Define the RTDB URL */
#define TEST_DATABASE_URL "test-3df9c-default-rtdb.firebaseio.com"

#define ORE_DATABASE_URL "ore-locks-default-rtdb.firebaseio.com"

#define DATABASE_URL ORE_DATABASE_URL //<databaseName>.firebaseio.com or <databaseName>.<region>.firebasedatabase.app

/* 4. Define the user Email and password that alreadey registerd or added in your project */
#define USER_EMAIL "cromeo5112@gmail.com"
#define USER_PASSWORD "King1234"

#define RELAY_PIN 0

#define TEST_LOCK_REQUEST_PATH "/lock_request"
#define TEST_IS_LOCKED_PATH "/locked"

#define ORE_LOCK_REQUEST_PATH "/Account_id/Primary_Keys/Building_id/Door_id/lock_request"
#define ORE_IS_LOCKED_PATH "/Account_id/Primary_Keys/Building_id/Door_id/locked"

#define LOCK_REQUEST_PATH ORE_LOCK_REQUEST_PATH
#define IS_LOCKED_PATH ORE_IS_LOCKED_PATH

//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;

unsigned long sendDataPrevMillis = 0;

void setup()
{

  Serial.begin(9600);
  
  pinMode(RELAY_PIN, OUTPUT);
  
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting to Wi-Fi");
  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.print(".");
    delay(300);
  }
  Serial.println();
  Serial.print("Connected with IP: ");
  Serial.println(WiFi.localIP());
  Serial.println();

  Serial.printf("Firebase Client v%s\n\n", FIREBASE_CLIENT_VERSION);

  /* Assign the api key (required) */
  config.api_key = API_KEY;

  /* Assign the user sign in credentials */
  auth.user.email = USER_EMAIL;
  auth.user.password = USER_PASSWORD;

  /* Assign the RTDB URL (required) */
  config.database_url = DATABASE_URL;

  /* Assign the callback function for the long running token generation task */
  config.token_status_callback = tokenStatusCallback; //see addons/TokenHelper.h

  //Or use legacy authenticate method
  //config.database_url = DATABASE_URL;
  //config.signer.tokens.legacy_token = "<database secret>";

  //To connect without auth in Test Mode, see Authentications/TestMode/TestMode.ino

  //////////////////////////////////////////////////////////////////////////////////////////////
  //Please make sure the device free Heap is not lower than 80 k for ESP32 and 10 k for ESP8266,
  //otherwise the SSL connection will fail.
  //////////////////////////////////////////////////////////////////////////////////////////////

  Firebase.begin(&config, &auth);

  //Comment or pass false value when WiFi reconnection will control by your code or third party library
  Firebase.reconnectWiFi(true);

  Firebase.setDoubleDigits(5);
}

void loop()
{

  //Firebase.ready works for authentication management and should be called repeatedly in the loop.

  if (Firebase.ready() && (millis() - sendDataPrevMillis > 15000 || sendDataPrevMillis == 0))
  {
    sendDataPrevMillis = millis();

    Firebase.RTDB.getInt(&fbdo, F(LOCK_REQUEST_PATH));
    int lock_request = fbdo.to<int>();
    
    Serial.print("Lock Request: ");
    Serial.print(lock_request);
    Serial.print(", ");
    
    if(lock_request == 1){ // locks door
      
      digitalWrite(RELAY_PIN, HIGH);
      Firebase.RTDB.setInt(&fbdo, F(LOCK_REQUEST_PATH), 0);
      Firebase.RTDB.setBool(&fbdo, F(IS_LOCKED_PATH), true);
      Serial.println("Door Locked");
      
    }else if (lock_request == 2){ // unlocks door
      
      digitalWrite(RELAY_PIN, LOW);
      Firebase.RTDB.setInt(&fbdo, F(LOCK_REQUEST_PATH), 0);
      Firebase.RTDB.setBool(&fbdo, F(IS_LOCKED_PATH), false);
      Serial.println("Door Unlocked");      
    
    }else{
      Serial.println("Awaiting Request...");
    }
  }
}

/** NOTE: 
 * When you trying to get boolean, integer and floating point number using getXXX from string, json 
 * and array that stored on the database, the value will not set (unchanged) in the 
 * FirebaseData object because of the request and data response type are mismatched.
 * 
 * There is no error reported in this case, until you set this option to true
 * config.rtdb.data_type_stricted = true;
 * 
 * In the case of unknown type of data to be retrieved, please use generic get function and cast its value to desired type like this
 * 
 * Firebase.RTDB.get(&fbdo, "/path/to/node");
 * 
 * float value = fbdo.to<float>();
 * String str = fbdo.to<String>();
 * 
 */

/// PLEASE AVOID THIS ////

//Please avoid the following inappropriate and inefficient use cases
/**
 * 
 * 1. Call get repeatedly inside the loop without the appropriate timing for execution provided e.g. millis() or conditional checking,
 * where delay should be avoided.
 * 
 * Everytime get was called, the request header need to be sent to server which its size depends on the authentication method used, 
 * and costs your data usage.
 * 
 * Please use stream function instead for this use case.
 * 
 * 2. Using the single FirebaseData object to call different type functions as above example without the appropriate 
 * timing for execution provided in the loop i.e., repeatedly switching call between get and set functions.
 * 
 * In addition to costs the data usage, the delay will be involved as the session needs to be closed and opened too often
 * due to the HTTP method (GET, PUT, POST, PATCH and DELETE) was changed in the incoming request. 
 * 
 * 
 * Please reduce the use of swithing calls by store the multiple values to the JSON object and store it once on the database.
 * 
 * Or calling continuously "set" or "setAsync" functions without "get" called in between, and calling get continuously without set 
 * called in between.
 * 
 * If you needed to call arbitrary "get" and "set" based on condition or event, use another FirebaseData object to avoid the session 
 * closing and reopening.
 * 
 * 3. Use of delay or hidden delay or blocking operation to wait for hardware ready in the third party sensor libraries, together with stream functions e.g. Firebase.RTDB.readStream and fbdo.streamAvailable in the loop.
 * 
 * Please use non-blocking mode of sensor libraries (if available) or use millis instead of delay in your code.
 * 
 * 4. Blocking the token generation process.
 * 
 * Let the authentication token generation to run without blocking, the following code MUST BE AVOIDED.
 * 
 * while (!Firebase.ready()) <---- Don't do this in while loop
 * {
 *     delay(1000);
 * }
 * 
 */
