using UnityEngine;
using System.Collections;

public class WallCollider : MonoBehaviour {
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Cart") {
			col.gameObject.GetComponentInParent<PlayerMovement> ().Crash ("wall");
		}
	}

}
