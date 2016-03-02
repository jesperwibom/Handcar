using UnityEngine;
using System.Collections;

public class SwitchActivator : MonoBehaviour {

	public SwitchCollider switchColliderL;
	public SwitchCollider switchColliderC;
	public SwitchCollider switchColliderR;

	void onTriggerEnter(Collider col){
		GameObject go = col.gameObject;
		if (go.tag == "Player1" || go.tag == "Player2") {
			if (switchColliderL != null && (switchColliderL.player1 || switchColliderL.player2)) {
				if (go.GetComponent<PlayerMovement> ().isGrounded ()) {
					go.GetComponent<PlayerMovement> ().SetPathPoints(switchColliderL.GetEnterPoint(), switchColliderL.GetExitPoint());
				} else {
					go.GetComponent<PlayerMovement> ().ExtendExitPoint(1f);
				}
			}
			if (switchColliderC != null && (switchColliderC.player1 || switchColliderC.player2)) {
				if (go.GetComponent<PlayerMovement> ().isGrounded ()) {
					go.GetComponent<PlayerMovement> ().SetPathPoints(switchColliderC.GetEnterPoint(), switchColliderC.GetExitPoint());
				} else {
					go.GetComponent<PlayerMovement> ().ExtendExitPoint(1f);
				}
			}
			if (switchColliderR != null && (switchColliderR.player1 || switchColliderR.player2)) {
				if (go.GetComponent<PlayerMovement> ().isGrounded ()) {
					go.GetComponent<PlayerMovement> ().SetPathPoints(switchColliderR.GetEnterPoint(), switchColliderR.GetExitPoint());
				} else {
					go.GetComponent<PlayerMovement> ().ExtendExitPoint(1f);
				}
			}
		}
	}
}
