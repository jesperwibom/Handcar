using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GoalScript : MonoBehaviour {

	public Text flashingText;
	AudioSource audioSource;

	void Start () {






	}
	void Update(){
		
	}
	void OnTriggerEnter(Collider col){
	
		if (col.gameObject.name == "Cart") {
			StartCoroutine (BlinkText ());
		}
	}

	public IEnumerator BlinkText(){
		while (true) {
			flashingText.text = "";
			yield return new WaitForSeconds (.5f);
			flashingText.text = "GOOD JOB!";
			yield return new WaitForSeconds (.5f);

		}
	}
}
