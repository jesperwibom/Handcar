using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
 * Count down timer
 * Check lose condition (time runs out)
 * Restart level (reset player)
 * 
 * Refill timer
 * Check for checkpoint triggers
 * 
 * Keep timer updated
 * Take reference to goal collider
 * Check victory conditions
 */

public class TimeManager : MonoBehaviour {

	public Text counter;
	public Text bonus;

	public GameObject panelWinLose;
	public Text textWinLose;
	public Text total;

	bool timerIsRunning = false;
	int secondsLeft = 30;
	float totalSeconds = 0;

	bool gameWon = false;
	bool gameLost = false;

	void Start(){
		panelWinLose.SetActive(false);
		bonus.enabled = false;
	}

	void Update(){
		if (secondsLeft < 0) {
			Lose ();
		}
	}
		
	public void StartTimer(){
		if (!timerIsRunning) {
			StartCoroutine (Timer ());
			StartCoroutine (TotalTimer ());
		}
	}

	public void RefillTimer(int seconds){
		secondsLeft += seconds;
		bonus.text = "+" + seconds.ToString ();
		StartCoroutine (BlinkBonus ());
	}

	public void Win(){
		if (!gameLost) {
			gameWon = true;
			panelWinLose.SetActive (true);
			textWinLose.text = "YOU WIN";
			total.text = totalSeconds.ToString ("F2");
			counter.enabled = false;
			StartCoroutine (BlinkTotal ());
		}
	}

	public void Lose(){
		gameLost = true;
		PlayerMovement pm = GameObject.FindGameObjectWithTag ("Player1").GetComponent<PlayerMovement>();
		pm.Crash ("ground");
		//DisplayRestart ();
	}

	IEnumerator Timer(){
		timerIsRunning = true;
		while (secondsLeft > 0 && timerIsRunning == true) {
			secondsLeft--;
			counter.text = secondsLeft.ToString();
			yield return new WaitForSeconds(1);
		}
		if (!gameWon) {
			Lose ();
		}
		timerIsRunning = false;
	}

	IEnumerator TotalTimer(){
		while (true) {
			yield return new WaitForSeconds(0.1f);
			totalSeconds += 0.1f;
		}
	}

	IEnumerator BlinkBonus(){
		for (int i = 0; i < 7; i++) {
			bonus.enabled = !bonus.enabled;
			if (bonus.enabled) {
				yield return new WaitForSeconds(0.4f);
			} else {
				yield return new WaitForSeconds(0.3f);
			}

		}
		bonus.enabled = false;
	}

	IEnumerator BlinkTotal(){
		while (true) {
			total.enabled = !total.enabled;
			yield return new WaitForSeconds (0.6f);
		}
	}


}
