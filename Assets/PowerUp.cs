using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public bool timeBonus = true;
	public bool powerBonus = false;
	public bool speedBonus = false;

	public GameObject player;
	public TimeManager tm;

	public AudioSource audioClip;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * (75f*Time.deltaTime), Space.World);
	}

	void OnTriggerEnter(Collider col){
		if (col.name == "Cart") {
			if (timeBonus) {
				tm.RefillTimer (2);
				audioClip.Play ();
			}
			if (powerBonus) {
				player.GetComponent<PlayerPower> ().AdjustPower(5f);
				audioClip.Play ();
			}
			if (speedBonus) {
				player.GetComponent<PlayerMovement> ().ChangeSpeed (2f);
				audioClip.Play ();
			}
			Destroy (gameObject);
		}
	}
}
