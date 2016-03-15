using UnityEngine;
using System.Collections;

public class RotateToTravelDirection : MonoBehaviour {

	public PlayerMovement pm;

	void FixedUpdate () {
		if (pm.playerActive) {
			if (pm.isGrounded()) {
				transform.LookAt (new Vector3 (pm.GetExitPoint ().x, transform.position.y, pm.GetExitPoint ().z));
			} else {
				if (pm.floatSwitch == 0) {
					transform.LookAt (new Vector3 (pm.GetExitPoint ().x, transform.position.y, pm.GetExitPoint ().z));
				} else if (pm.floatSwitch == -1 || pm.floatSwitch == 1) {
					transform.LookAt (new Vector3 (pm.GetExitPoint ().x, transform.position.y, transform.position.z));
				}
			}
		}
	}
}
