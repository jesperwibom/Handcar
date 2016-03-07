using UnityEngine;
using System.Collections;

public class SwitchActivator : MonoBehaviour {

	public SwitchCollider switchColliderL;
	public SwitchCollider switchColliderC;
	public SwitchCollider switchColliderR;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player1Collider" || col.gameObject.tag == "Player2Collider") {
			if (!col.gameObject.GetComponentInParent<PlayerMovement> ().isGrounded ()) {
				StartCoroutine (WaitForGround (col.gameObject));
			} else {
				HandlePlayer (col.gameObject);
			}
		}
	}

	void HandlePlayer(GameObject go){

		PlayerMovement playerMovement = go.GetComponentInParent<PlayerMovement> ();

		string tag = go.tag;
		string player = "player";

		if (tag == "Player1Collider") {
			player = "Player1";
		} else if (tag == "Player2Collider") {
			player = "Player2";
		}

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

	IEnumerator WaitForGround(GameObject go){
		while (!go.GetComponentInParent<PlayerMovement> ().isGrounded ()) {
			yield return null;
		}
		HandlePlayer (go);
	}
}
