using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour {

	Text flashingText;
	AudioSource audioSource;

	void Start () {
	
		flashingText = GetComponent<Text> ();
		StartCoroutine (BlinkText ());
		audioSource = GetComponent<AudioSource> ();


	}
	void Update(){
		if(Input.GetKeyDown("return")){
			audioSource.Play ();
		}
	}
	
	public IEnumerator BlinkText(){
		while (true) {
			flashingText.text = "";
			yield return new WaitForSeconds (.5f);
			flashingText.text = "PUMP TO START!";
			yield return new WaitForSeconds (.5f);

		}
	}
}
