using UnityEngine;
using System.Collections;
using Uniduino;

public class Controller {

	Arduino arduino;

	bool controllerMode = true;

	int centerSensorPin = 0;
	int leftBtnPin = 6;
	int rightBtnPin = 7;
	int leftSwitchPin = 8;
	int rightSwitchPin = 9;

	int leftLedPin = 10;
	int rightLedPin = 11;

	int currentLeftLedState = 0;
	int currentRightLedState = 0;

	bool fadeLeftLed = false;
	bool fadeRightLed = false;
	float fadeSpeed = 200f;
	bool fadeSync = false;


	bool blinkLeftLed = false;
	bool blinkRightLed = false;
	float blinkSpeed = 200f;
	bool blinkSync = false;

	public Controller(Arduino board){
		arduino = board;
		arduino.Log = (s) => Debug.Log("Arduino: " +s);
		arduino.Setup(ConfigurePins);
	}

	void ConfigurePins ()
	{
		arduino.pinMode(centerSensorPin, PinMode.INPUT);
		arduino.pinMode(leftBtnPin, PinMode.INPUT);
		arduino.pinMode(rightBtnPin, PinMode.INPUT);
		arduino.pinMode(leftSwitchPin, PinMode.INPUT);
		arduino.pinMode(rightSwitchPin, PinMode.INPUT);

		arduino.reportAnalog(centerSensorPin, 1);
		arduino.reportDigital((byte)(leftBtnPin/8), 1);
		arduino.reportDigital((byte)(rightBtnPin/8), 1);
		arduino.reportDigital((byte)(leftSwitchPin/8), 1);
		arduino.reportDigital((byte)(rightSwitchPin/8), 1);

		arduino.pinMode(leftLedPin, PinMode.PWM);
		arduino.pinMode(rightLedPin, PinMode.PWM);
	}

	public void UpdateLeds(){
		if (fadeSync && fadeLeftLed && fadeRightLed) {
			currentRightLedState = currentLeftLedState;
		}

		if (fadeLeftLed) {
			currentLeftLedState = (int)Mathf.PingPong (Time.time * fadeSpeed, 255);
			arduino.analogWrite (leftLedPin, currentLeftLedState);
		} else {
			arduino.analogWrite (leftLedPin, currentLeftLedState);
		}
		if (fadeRightLed) {
			currentRightLedState = (int)Mathf.PingPong (Time.time * fadeSpeed, 255);
			arduino.analogWrite (rightLedPin, currentRightLedState);
		} else {
			arduino.analogWrite (rightLedPin, currentRightLedState);
		}
	}


	public int[] GetInput(){
		int[] arr = {
			arduino.analogRead (centerSensorPin),
			arduino.digitalRead (leftBtnPin),
			arduino.digitalRead (rightBtnPin),
			arduino.digitalRead (leftSwitchPin),
			arduino.digitalRead (rightSwitchPin)
		};
		return arr;
	}

	public void SetLed(string cmd, int value){
		switch (cmd) {
		case "both":
			fadeLeftLed = false;
			fadeRightLed = false;
			blinkLeftLed = false;
			blinkRightLed = false;
			currentLeftLedState = value;
			currentRightLedState = value;
			break;
		case "left":
			fadeLeftLed = false;
			blinkLeftLed = false;
			currentLeftLedState = value;
			break;
		case "right":
			fadeRightLed = false;
			blinkRightLed = false;
			currentRightLedState = value;
			break;
		default:
			Debug.Log ("!WARNING: no LED string recognised when calling Controller.SetLed(string cmd, int value)");
			break;
		}
	}

	public void SetLedFade(string cmd, float speed, bool sync){
		fadeSpeed = speed;
		fadeSync = sync;
		switch (cmd) {
		case "both":
			blinkLeftLed = false;
			blinkRightLed = false;
			fadeLeftLed = true;
			fadeRightLed = true;
			break;
		case "left":
			blinkLeftLed = false;
			fadeLeftLed = true;
			break;
		case "right":
			blinkRightLed = false;
			fadeRightLed = true;
			break;
		default:
			Debug.Log ("!WARNING: no LED string recognised when calling Controller.SetLedFade(string cmd, float speed, bool sync)");
			break;
		}
	}

	public void SetLedFade(string cmd, float speed){
		fadeSpeed = speed;
		switch (cmd) {
		case "both":
			blinkLeftLed = false;
			blinkRightLed = false;
			fadeLeftLed = true;
			fadeRightLed = true;
			break;
		case "left":
			blinkLeftLed = false;
			fadeLeftLed = true;
			break;
		case "right":
			blinkRightLed = false;
			fadeRightLed = true;
			break;
		default:
			Debug.Log ("!WARNING: no LED string recognised when calling Controller.SetLedFade(string cmd, float speed)");
			break;
		}
	}

	public void SetLedFade(string cmd){
		switch (cmd) {
		case "both":
			blinkLeftLed = false;
			blinkRightLed = false;
			fadeLeftLed = true;
			fadeRightLed = true;
			break;
		case "left":
			blinkLeftLed = false;
			fadeLeftLed = true;
			break;
		case "right":
			blinkRightLed = false;
			fadeRightLed = true;
			break;
		default:
			Debug.Log ("!WARNING: no LED string recognised when calling Controller.SetLedFade(string cmd)");
			break;
		}
	}

	public bool[] GetLedFade(){
		bool[] arr = { fadeLeftLed, fadeRightLed };
		return arr;
	}

	public int[] GetLed(){
		int[] arr = { currentLeftLedState, currentRightLedState };
		return arr;
	}

	public int GetLed(string cmd){
		switch (cmd) {
		case "left":
			return currentLeftLedState;
		case "right":
			return currentRightLedState;
		default:
			Debug.Log ("!WARNING: no LED string recognised when calling Controller.GetLed(string cmd)");
			return 0;
		}
	}

}
