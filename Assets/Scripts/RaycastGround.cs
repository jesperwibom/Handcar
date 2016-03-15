using UnityEngine;
using System.Collections;

public class RaycastGround : MonoBehaviour {

	PlayerMovement pm;

	void Start(){
		pm = gameObject.GetComponent<PlayerMovement> ();
	}

	void Update () {
		RaycastHit hit;
		float hitDistance;

		//use this if ray is following objects rotations (instead of Vector3.down)
		//Vector3 down = transform.TransformDirection (Vector3.down) * 5;

		Debug.DrawRay (transform.position, Vector3.down, Color.green);

		if (Physics.Raycast (transform.position, (Vector3.down), out hit)) {
			hitDistance = hit.distance;
			//print (hitDistance + " to " + hit.collider.gameObject.name);
			if ((hit.collider.gameObject.name == "Ground" || hit.collider.gameObject.tag == "ground")&& pm.isGrounded() == true) {
				pm.Crash ("ground");
			}
		}
	}
}
