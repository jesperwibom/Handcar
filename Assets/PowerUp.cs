using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

	public bool timeBonus = true;
	public bool powerBonus = false;
	public bool speedBonus = false;

	public GameObject player;
	public TimeManager tm;

	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up * (75f*Time.deltaTime), Space.World);
	}

	void OnTriggerEnter(Collider col){
		if (col.name == "Cart") {
			if (timeBonus) {
				tm.RefillTimer (2);
			}
			if (powerBonus) {
				player.GetComponent<PlayerPower> ().AdjustPower(5f);
			}
			if (speedBonus) {
				player.GetComponent<PlayerMovement> ().ChangeSpeed (2f);
			}
			Destroy (gameObject);
		}
	}
}
