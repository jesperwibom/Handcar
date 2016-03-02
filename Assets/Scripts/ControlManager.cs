using UnityEngine;
using System.Collections;


/* 
 * This script communicates with the Arduino based physical controllers.
 * It takes their input and calls the PlayerMovement scripts.
 * It also will include public methods for sending commands to the controllers.
 */

public class ControlManager : MonoBehaviour {

	public PlayerMovement player1;
	public PlayerMovement player2;

	public bool keyboardControl = false;

	//Serial port here

	int deadZoneL = 125;
	int deadZoneR = 130;
	int maxValueL = 5;
	int maxValueR = 250;
	int changeThreshold = 2;


	bool player1Turn = true;
	int player1Value = 127; //0 is max left user, 255 is max right user
	float player1Force1 = 0;
	float player1Force2 = 0;

	//if reached maxValueThreshold : change to other user
	//or if value is less than previous meassurement by more than changeThreshold : change to other user

	//light led when user can push
	//a user can only use button for honking if it is his turn

	bool player2Turn = true;

	void Start(){
		//StartCoroutine(CalculateForce);
	}

	void Update(){
		if(keyboardControl && Input.GetKeyDown("right")){
			player1.ChangeSpeed (0.5f);
		}
		if(keyboardControl && Input.GetKeyDown("space")){
			player1.Jump ();
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
