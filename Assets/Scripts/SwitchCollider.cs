using UnityEngine;
using System.Collections;

/*
 * Has two uses:
 * check for players and give them new path points (through SwitchActivator)
 * check for track switch collider and changethe exit point state if applicable
 */

public class SwitchCollider : MonoBehaviour {

	public Transform enterPoint;

	public Transform exitPointL;
	public Transform exitPointC;
	public Transform exitPointR;

	private Transform activeExitPoint;

	public SwitchModel switchModel;

	//set to private and use CheckPlayer() instead
	public bool player1 = false;
	public bool player2 = false;

	private int currentState = 0;



	// Use this for initialization
	void Start () {
		SetActiveExitPoint (exitPointC);
	
	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.tag == "Player1Collider") {
			player1 = true;
		}
		if (col.gameObject.tag == "Player2Collider") {
			player2 = true;
		}

		if (col.gameObject.name == "TrackSwitch") {
			if (col.GetComponent<TrackSwitch> ().switchState == -1) {
				SwitchLeft ();
			} else if (col.GetComponent<TrackSwitch> ().switchState == 1) {
				SwitchRight ();
			}
		}

	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Player1Collider") {
			player1 = false;
		}
		if (col.gameObject.tag == "Player2Collider") {
			player2 = false;
		}

	}

	void SetActiveExitPoint(Transform exitPoint){
		activeExitPoint = exitPoint;
		if (switchModel != null) {
			switchModel.UpdateModel(gameObject.name,currentState);
		}

	}

	void SwitchLeft(){
		if (activeExitPoint == exitPointL) {
			// Call SoundManager.NoSwitch()
		} else if (activeExitPoint == exitPointC) {
			if (exitPointL != null) {
				currentState = -1;
				SetActiveExitPoint (exitPointL);
			} else {
				// Call SoundManager.NoSwitch()
			}
		} else if (activeExitPoint == exitPointR) {
			currentState = 0;
			SetActiveExitPoint (exitPointC);
		}
	}

	void SwitchRight(){
		if (activeExitPoint == exitPointR) {
			// Call SoundManager.NoSwitch()
		} else if (activeExitPoint == exitPointC) {
			if (exitPointR != null) {
				currentState = 1;
				SetActiveExitPoint (exitPointR);
			} else {
				// Call SoundManager.NoSwitch()
			}
		} else if (activeExitPoint == exitPointL) {
			currentState = 0;
			SetActiveExitPoint (exitPointC);
		}
	}

	public Vector3 GetEnterPoint(){
		return enterPoint.position;
	}

	public Vector3 GetExitPoint(){
		return activeExitPoint.position;
	}

	public bool CheckPlayer(string player){
		if (player == "player1" || player == "Player1" || player == "PLAYER1") {
			return player1;
		} else if (player == "player2" || player == "Player2" || player == "PLAYER2") {
			return player2;
		} else {
			return false;
		}
	}
}
