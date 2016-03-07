using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoalController : MonoBehaviour {
	private BoxCollider player1Collider;
	private BoxCollider player2Collider;
	private GameObject player1;
	private GameObject player2;
	public Text goalText;
	private bool isVisible = false;
	private int counter;

	// Use this for initialization
	void Start () {
		goalText.text = "";
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player1");
		player1Collider = GameObject.FindGameObjectWithTag ("Player1Collider").GetComponent<BoxCollider>();

	
	}
	void OnTriggerEnter(Collider other){
		if (other = player1Collider) {
			StartCoroutine(WaitAndPrint(1f));
			Debug.Log ("Player entered goal!");

		}
	}

	IEnumerator WaitAndPrint(float waitTime) {
		while (true) {
			if (counter < 5) {
				if (!isVisible) {
					goalText.text = "A Winner Is You!";
					isVisible = true;
					counter++;
				} else {
					goalText.text = "";
					isVisible = false;
					}




		
			}
			else{
				StopAllCoroutines ();
			}
		}
	}
}
