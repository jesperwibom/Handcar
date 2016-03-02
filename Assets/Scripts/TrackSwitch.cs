using UnityEngine;
using System.Collections;

public class TrackSwitch : MonoBehaviour {

	public int switchState = 0;

	BoxCollider collider;
	PlayerMovement playerMovement;

	void Start(){
		collider = gameObject.GetComponent<BoxCollider> ();
		collider.enabled = false;
		playerMovement = gameObject.GetComponentInParent<PlayerMovement> ();
	}

	public void  Switch(int state){
		switchState = state;
		StartCoroutine (Toggle());
	}

	void Active(bool active){
		collider.enabled = active;
	}

	IEnumerator Toggle(){
		Active (true);
		yield return null;
		Active (false);
	}

	void zDiff(){

		float enterDiff = playerMovement.transform.position.z - playerMovement.GetEnterPoint ().z;
		float exitDiff = playerMovement.transform.position.z - playerMovement.GetExitPoint ().z;

		if(exitDiff > -0.5f && exitDiff < 0.5f){

		} else if (enterDiff > -0.5f && enterDiff < 0.5f){

		} else {

		}
	}
}
