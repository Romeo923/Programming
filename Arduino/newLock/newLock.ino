#if defined(ESP32)
#include <WiFi.h>
#elif defined(ESP8266)
#include <ESP8266WiFi.h>
#endif

#include <Firebase_ESP_Client.h>

//Provide the token generation process info.
#include <addons/TokenHelper.h>

/* 1. Define the WiFi credentials */
#define WIFI_SSID "ColdSpot"
#define WIFI_PASSWORD "fr33Loder"

/* 2. Define the API Key */
#define API_KEY "AIzaSyA8LEQ25L0fQSlr-lMFR-d2hGI78Oes7XI"

/* 3. Define the project ID */
#define FIREBASE_PROJECT_ID "ore-locks"

/* 4. Define the user Email and password that alreadey registerd or added in your project */
#define USER_EMAIL "ENTER EMAIL"
#define USER_PASSWORD "ENTER PASSWORD"

#define RELAY_PIN D1

//Define Firebase Data object
FirebaseData fbdo;

FirebaseAuth auth;
FirebaseConfig config;

unsigned long dataMillis = 0;
int count = 0;

bool taskcomplete = false;

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

    /* Assign the callback function for the long running token generation task */
    config.token_status_callback = tokenStatusCallback;

    Firebase.begin(&config, &auth);
    
    Firebase.reconnectWiFi(true);
}

void loop()
{

    if (Firebase.ready() && (millis() - dataMillis > 1000 || dataMillis == 0))
    {
        dataMillis = millis();

        FirebaseJson content;

        String documentPath = "locks/1";

        String mask = "lockRequest";
        int lock_request = 0;
        FirebaseJson p;
        FirebaseJsonData jsonData;
        if (Firebase.Firestore.getDocument(&fbdo, FIREBASE_PROJECT_ID, "", documentPath.c_str(), mask.c_str()))
        {
            p.setJsonData(fbdo.payload().c_str());
            p.get(jsonData, "/fields/lockRequest/integerValue", true);
            lock_request = jsonData.stringValue.toInt();
            Serial.print("lock request: ");
            Serial.print(lock_request);
            Serial.print(", ");
        }else
            Serial.println(fbdo.errorReason());

        
        content.clear();

        if(lock_request == 1){ // locks door
      
          
          content.set("/fields/lockRequest/integerValue", 0);
          content.set("/fields/isOpen/booleanValue", false);
          
          if (Firebase.Firestore.patchDocument(&fbdo, FIREBASE_PROJECT_ID, "" /* databaseId can be (default) or empty */, documentPath.c_str(), content.raw(), "lockRequest,isOpen" /* updateMask */)){
              digitalWrite(RELAY_PIN, HIGH);
              Serial.println("Door Locked");
              
          }else
              Serial.println(fbdo.errorReason());
          
        }else if (lock_request == 2){ // unlocks door

          content.set("/fields/lockRequest/integerValue", 0);
          content.set("/fields/isOpen/booleanValue", true);

          if (Firebase.Firestore.patchDocument(&fbdo, FIREBASE_PROJECT_ID, "", documentPath.c_str(), content.raw(), "lockRequest,isOpen")){
              digitalWrite(RELAY_PIN, LOW);
              Serial.println("Door Unlocked");      

          }else
              Serial.println(fbdo.errorReason());
          
        }else{
          Serial.println("Awaiting Request...");
        }     
    }
}
