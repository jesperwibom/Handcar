using UnityEngine;
using System.Collections;


/* This script communicates with the Arduino based physical controllers.
 * It takes their input and calls the PlayerMovement scripts.
 * It also will include public methods for sending commands to the controllers.
 */

public class ControlManager : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;

	public bool keyboardControl = false;

	//Serial port here

	void Update(){
		if(keyboardControl && Input.GetKeyDown("right")){
			//player1.
		}
	}

}
