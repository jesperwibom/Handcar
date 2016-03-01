using UnityEngine;
using System.Collections;

public class SwitchCollider : MonoBehaviour {

	public Transform enterPoint;

	public Transform exitPointL;
	public Transform exitPointC;
	public Transform exitPointR;

	private Transform activeExitPoint;

	public bool player1 = false;
	public bool player2 = false;

	private int currentState = 0;



	// Use this for initialization
	void Start () {
		SetActiveExitPoint (exitPointC);
	
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player1") {
			player1 = true;

		}
		if (col.gameObject.tag == "Player2") {
			player2 = true;

		}
	}
	void onTriggerExit(Collider col){
		if (col.gameObject.tag == "Player1") {
			player1 = false;

		}
		if (col.gameObject.tag == "Player2") {
			player2 = false;

		}
	}

	void SetActiveExitPoint(Transform exitPoint){
		activeExitPoint = exitPoint;
		//Call railManager.UpdateModel()
	}

	void SwitchLeft(){
		if (activeExitPoint == exitPointL) {
			// Call soundManager.NoSwitch()
		} else if (activeExitPoint == exitPointC) {
			if (exitPointL != null) {
				currentState = -1;
				SetActiveExitPoint (exitPointL);
			} else {
				// Call soundManager.NoSwitch()
			}
		} else if (activeExitPoint == exitPointR) {
			currentState = 0;
			SetActiveExitPoint (exitPointC);
		}
	}

	void SwitchRight(){
		if (activeExitPoint == exitPointR) {
			// Call soundManager.NoSwitch()
		} else if (activeExitPoint == exitPointC) {
			if (exitPointR != null) {
				currentState = 1;
				SetActiveExitPoint (exitPointR);
			} else {
				// Call soundManager.NoSwitch()
			}
		} else if (activeExitPoint == exitPointL) {
			currentState = 0;
			SetActiveExitPoint (exitPointC);
		}
	}

	public Transform GetEnterPoint(){
		return enterPoint;
	}

	public Transform GetExitPoint(){
		return activeExitPoint;
	}
}
