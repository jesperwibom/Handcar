using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPower : MonoBehaviour {
	[Header("Power Slider")]
	public Slider powerSlider;
	[Header("Action energy cost")]
	public float delayTime = 1.8f;

	public float jumpCost = 30f;
	public float shiftCost = 10f;

	private float targetPower;
	private float currentPower;

	float timeLimit = 5.0f;

	PlayerMovement pm;

	bool jumpCheck = false;

	// Use this for initialization
	void Start () {
		powerSlider.value = powerSlider.minValue;
		currentPower = powerSlider.minValue;
		pm = gameObject.GetComponent<PlayerMovement> ();

	}

	// Update is called once per frame
	void Update() {
		if (!pm.isGrounded ()) {
			if (!jumpCheck) {
				targetPower = currentPower;
				jumpCheck = true;
			}

			targetPower -= 0.15f;
			if (currentPower <= 0) {
				pm.Jump ();
			}
		} else {
			jumpCheck = false;
		}

		if (currentPower > targetPower) {
			powerSlider.value -= 0.1f;
		} else if (currentPower < targetPower) {
			powerSlider.value += 0.1f;
		}

		timeLimit -= Time.deltaTime;

		// Deplate energy if player's been still for too long
		if (timeLimit <= 0 && targetPower > 0) {
			targetPower -= 0.1f;
		}

		currentPower = powerSlider.value;


	}




	public void AdjustPower(float powerAdjust){

		targetPower += powerAdjust * 5f;
		timeLimit = delayTime;
	}


	public float getPower ()
	{
		return currentPower;

	}

	// Method for controlmanager to check if player has enough energy to perform selected action
	public bool enoughEnergy(string action){
		bool enough = false;
		if (action == "jump") {
			if (currentPower >= jumpCost) {
				enough = true;

			} else {
				enough = false;

			}
		} else if (action == "shift") {
			if (currentPower >= shiftCost) {
				enough = true;

			}else{
				enough = false;
			}
		}
		return enough;
	}
}