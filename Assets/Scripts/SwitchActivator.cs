using UnityEngine;
using System.Collections;

public class SwitchActivator : MonoBehaviour {

	public SwitchCollider switchColliderL;
	public SwitchCollider switchColliderC;
	public SwitchCollider switchColliderR;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2") {
			HandlePlayer (col.gameObject);
		}
	}

	void HandlePlayer(GameObject go){

		PlayerMovement playerMovement = go.GetComponentInParent<PlayerMovement> ();
		string player = go.tag;

		if (switchColliderL != null && switchColliderL.CheckPlayer(player)) {
			if (playerMovement.isGrounded ()) {
				playerMovement.SetPathPoints(switchColliderL.GetEnterPoint(), switchColliderL.GetExitPoint());
			} else {
				playerMovement.ExtendExitPoint(2f);
			}
		}
		if (switchColliderC != null && switchColliderC.CheckPlayer(player)) {
			if (playerMovement.isGrounded ()) {
				playerMovement.SetPathPoints(switchColliderC.GetEnterPoint(), switchColliderC.GetExitPoint());
			} else {
				playerMovement.ExtendExitPoint(2f);
			}
		}
		if (switchColliderR != null && switchColliderR.CheckPlayer(player)) {
			if (playerMovement.isGrounded ()) {
				playerMovement.SetPathPoints(switchColliderR.GetEnterPoint(), switchColliderR.GetExitPoint());
			} else {
				playerMovement.ExtendExitPoint(2f);
			}
		}
	}
}
