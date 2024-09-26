const int analogPins[] = {A0, A1, A2, A3, A4}; // Analog pins for the voltage divider, now including A4
const float knownResistor = 100000.0; // Replace with your known resistor value in ohms
const float vcc = 5.0; // Voltage supplied to the voltage divider

void setup() {
  Serial.begin(115200); // Start serial communication at 115200 baud rate
}

void loop() {
  unsigned long currentTimeMillis = millis(); // Get the current time in milliseconds
  float currentTimeSec = currentTimeMillis / 1000.0; // Convert milliseconds to seconds

  for (int i = 0; i < 5; i++) { // Loop through all five analog pins
    float v_out = analogRead(analogPins[i]) * (vcc / 1023.0); // Read and calculate the voltage across the known resistor
    float unknownResistor = (v_out / (vcc - v_out)) * knownResistor; // Calculate the unknown resistance using the voltage divider formula

    // Send the data in the specified format: <seconds_since_start>,<label>,<resistance_value>
    //Serial.print('command:');
    //Serial.print(currentTimeSec, 3);   // Seconds since start, formatted to 3 decimal places
    Serial.print("ID:");                 // Comma as a separator
    Serial.print( i ); 
    //Serial.print((char)('A' + i));     // Label for the measurement point, now including 'E' for the fifth measurement
    Serial.print(", R:");                 // Comma as a separator
    Serial.println(unknownResistor + ';');   // Resistance value and new line
  }

  delay(100); // Wait for a while before taking the next measurements
}
