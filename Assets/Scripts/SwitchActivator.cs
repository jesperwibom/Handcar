using UnityEngine;
using System.Collections;

public class SwitchActivator : MonoBehaviour {

	public SwitchCollider switchColliderL;
	public SwitchCollider switchColliderC;
	public SwitchCollider switchColliderR;

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2") {
			PlayerMovement playerMovement = col.gameObject.GetComponentInParent<PlayerMovement> ();
			if (switchColliderL != null && (switchColliderL.player1 || switchColliderL.player2)) {
				if (playerMovement.isGrounded ()) {
					playerMovement.SetPathPoints(switchColliderL.GetEnterPoint(), switchColliderL.GetExitPoint());
				} else {
					playerMovement.ExtendExitPoint(2f);
				}
			}
			if (switchColliderC != null && (switchColliderC.player1 || switchColliderC.player2)) {
				if (playerMovement.isGrounded ()) {
					playerMovement.SetPathPoints(switchColliderC.GetEnterPoint(), switchColliderC.GetExitPoint());
				} else {
					playerMovement.ExtendExitPoint(2f);
				}
			}
			if (switchColliderR != null && (switchColliderR.player1 || switchColliderR.player2)) {
				if (playerMovement.isGrounded ()) {
					playerMovement.SetPathPoints(switchColliderR.GetEnterPoint(), switchColliderR.GetExitPoint());
				} else {
					playerMovement.ExtendExitPoint(2f);
				}
			}
		}
	}
}
