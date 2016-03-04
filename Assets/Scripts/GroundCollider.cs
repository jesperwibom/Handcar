using UnityEngine;
using System.Collections;

public class GroundCollider : MonoBehaviour {
	
	void OnTriggerEnter(Collider col){
		if (col.gameObject.name == "Cart") {
			col.gameObject.GetComponentInParent<PlayerMovement> ().Crash ("ground");
		}
	}

}
