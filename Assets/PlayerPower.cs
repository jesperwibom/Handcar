using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPower : MonoBehaviour {
	[Header("Power Slider")]
	public Slider powerSlider;
	[Header("Energy Textfield")]
	public Text energyText;
	[Header("Action energy cost")]
	public float jumpCost = 50f;
	public float shiftCost = 20f;


	private float power;

	// lower power to this when using actions
	private float targetPower; 

	// Booleans for validation check
	private bool jumping;
	private bool switching;


	private bool increasing = false;
	private bool grounded = true;


	private float powerAdjust;

	private float previousPower;
	private float currentPower;

	float timeLimit = 5.0f;
	float decreaseTimer = 10000f;

	// Use this for initialization
	void Start () {
		powerSlider.value = powerSlider.minValue;
		power = powerSlider.minValue;

	}
	
	// Update is called once per frame
	void Update() {
		if (jumping)
		if (currentPower <= targetPower) {
			timeLimit = 1.5f;
			jumping = false;	


		} else {
			timeLimit = 1.5f;
			powerSlider.value -= 1f;
		}
		if (switching)
		if (currentPower <= targetPower) {
			timeLimit = 2f;
			switching = false;	

		} else {
			timeLimit = 1.5f;
			powerSlider.value -= 2f;
		}
			
		timeLimit -= Time.deltaTime;

		// Deplate energy if player's been still for too long

		if (timeLimit < 1) {
			// Decrease timeLimit.
			decreaseTimer -= Time.deltaTime;
			if (decreaseTimer > 1) {
				powerSlider.value -= 0.25f;
			}


		}
		currentPower = powerSlider.value;
		energyText.text = powerSlider.value.ToString();
	}
	public void AdjustPower(float powerAdjust){
		if (!jumping) {
		
			this.powerAdjust = powerAdjust;
		
		if (!jumping) {
			power = currentPower;
			power += powerAdjust * 5f;
			powerSlider.value = power;

			timeLimit = 1.5f;
		}
	}
	}

	public void JumpAction(){
		
		targetPower = currentPower - jumpCost;
		//StartCoroutine(jump());
		jumping = true;


	}

	public void ShiftAction(){
		targetPower =+ currentPower - shiftCost;
		switching = true;
		//	StartCoroutine (shift());
	}

	public float getPower ()
	{
		return currentPower;

	}
	public float getJumpCost ()
	{
		return jumpCost;
}
	public void isGrounded(bool grounded){
		this.grounded = grounded;
	}

	/* IEnumerator jump() {

		 decreasing = true;
		yield return new WaitForSeconds (60/jumpCost);
		Debug.Log ("jump cost was" + 60/jumpCost);
		decreasing = false;

		timeLimit = 1.5f;
	}
	IEnumerator shift() {

		decreasing = true;
		yield return new WaitForSeconds (shiftCost/60);
		Debug.Log ("jump cost was" + shiftCost/60);
		decreasing = false;
		timeLimit = 1.5f;
	}
	*/ 

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