using UnityEngine;
using System.Collections;


/* 
 * This script communicates with the Arduino based physical controllers.
 * It takes their input and calls the PlayerMovement scripts.
 * It also will include public methods for sending commands to the controllers.
 */

public class ControlManagerOld : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public bool keyboardControl = false;

	public bool player1active;
	public bool player2active;

	//Serial port here

	int deadZoneL = 125;
	int deadZoneR = 130;
	int maxValueL = 5;
	int maxValueR = 250;
	int changeThreshold = 2;


	PlayerMovement player1Movement;
	PlayerTrackSwitch player1TrackSwitch;
	bool player1Turn = true;
	int player1Value = 127; //0 is max left user, 255 is max right user
	float player1Force1 = 0;
	float player1Force2 = 0;

	PlayerMovement player2Movement;
	PlayerTrackSwitch player2TrackSwitch;
	bool player2Turn = true;
	int player2Value = 127; //0 is max left user, 255 is max right user
	float player2Force1 = 0;
	float player2Force2 = 0;

	//if reached maxValueThreshold : change to other user
	//or if value is less than previous meassurement by more than changeThreshold : change to other user

	//light led when user can push
	//a user can only use button for honking if it is his turn

	void Start(){
		if (player1active) {
			player1Movement = player1.GetComponent<PlayerMovement> ();
			player1TrackSwitch = player1.GetComponent<PlayerTrackSwitch> ();
		}
		if (player2active) {
			player2Movement = player2.GetComponent<PlayerMovement> ();
			player2TrackSwitch = player2.GetComponent<PlayerTrackSwitch> ();
		}
		//StartCoroutine(CalculateForce);
	}

	void Update(){
		
		//PLAYER 1
		if (player1active) {
			if(keyboardControl && Input.GetKeyDown("right")){
				player1Movement.ChangeSpeed (0.5f);
			}
			if(keyboardControl && Input.GetKeyDown("up")){
				player1TrackSwitch.SwitchLeft();
			}
			if(keyboardControl && Input.GetKeyDown("down")){
				player1TrackSwitch.SwitchRight();
			}
			if(keyboardControl && Input.GetKeyDown("space")){
				player1Movement.Jump();
			}
		}


		//PLAYER 2
		if (player2active) {
			if (keyboardControl && Input.GetKeyDown ("d")) {
				player2Movement.ChangeSpeed (0.5f);
			}
			if (keyboardControl && Input.GetKeyDown ("w")) {
				player2TrackSwitch.SwitchLeft ();
			}
			if (keyboardControl && Input.GetKeyDown ("s")) {
				player2TrackSwitch.SwitchRight ();
			}
			if (keyboardControl && Input.GetKeyDown ("q")) {
				player2Movement.Jump ();
			}
		}
		//take serial data from arduino
		//arduino sends the hall effect sensor value mapped to 0-255 
		//center position is 127-128
		//this script then calculates the value change
		//use this to give a speed increase relative to how fast the players are pushing down

	}

	IEnumerator CalculateForce(){
		yield return null;
	}
}
