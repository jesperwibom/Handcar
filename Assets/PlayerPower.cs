using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerPower : MonoBehaviour {
	[Header("Power Slider")]
	public Slider powerSlider;
	private float power;
	public float jumpCost = 50f;
	private bool increasing = false;
	private bool grounded = true;


	private float powerAdjust;

	private float previousPower;
	private float currentPower;
	private bool decreasing = false;

	float timeLimit = 5.0f;
	float decreaseTimer = 10000f;

	// Use this for initialization
	void Start () {
		powerSlider.value = powerSlider.minValue;
		power = powerSlider.minValue;
	}
	
	// Update is called once per frame
	void Update () {
		if (decreasing) {
			powerSlider.value -= .7f;
		} 
		timeLimit -= Time.deltaTime;

		if (timeLimit < 1 && !decreasing) {
			// Decrease timeLimit.
			decreaseTimer -= Time.deltaTime;
			if (decreaseTimer > 1) {
				
				// translate backward.
				powerSlider.value -= 0.9f;
			}
			//Debug.Log (timeLimit);

		}
		currentPower = powerSlider.value;
	}
	public void AdjustPower(float powerAdjust){
		if (grounded) {
		
			this.powerAdjust = powerAdjust;
		
		if (!decreasing) {
			power = currentPower;
			power += powerAdjust * 5f;
			powerSlider.value = power;

			timeLimit = 1.5f;
		}
	}
	}

	public void JumpAdjust(){
		
		StartCoroutine(Jumping());

	}
	IEnumerator Jumping() {
		
		decreasing = true;
		yield return new WaitForSeconds (1f);

		decreasing = false;
		timeLimit = 1.5f;
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
}