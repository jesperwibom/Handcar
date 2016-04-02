using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {


		private Text pointer1;
		private Text pointer2;
	private Text level1;
	private Text level2;
		private AudioSource sound;
		private AudioSource confirm;

		// Use this for initialization
		void Start ()
		{

			pointer1 = GameObject.Find ("Pointer1").GetComponent<Text> ();
			pointer2 = GameObject.Find ("Pointer2").GetComponent<Text> ();
			level1 = GameObject.Find ("Level1").GetComponent<Text> ();
			level2 = GameObject.Find ("Level2").GetComponent<Text> ();
			pointer1.enabled = true;
			pointer2.enabled = false;
			sound = GameObject.Find ("MenuSound").GetComponent<AudioSource> ();
			confirm = GameObject.Find ("ConfirmSound").GetComponent<AudioSource> ();
		}

		void Update ()
		{
			if (Input.GetKeyDown ("down")) {
				pointer1.enabled = false;
				pointer2.enabled = true;
				sound.Play ();

			}
			if (Input.GetKeyDown ("up")) {
				pointer1.enabled = true;
				pointer2.enabled = false;
				sound.Play ();

			}
			if (Input.GetKeyDown ("e")) {
				if (pointer1.enabled == true) {
					StartCoroutine (Go (level1));
				}
				if (pointer2.enabled) {
					StartCoroutine (Go (level2));
				}
			}


		}

		IEnumerator Go (Text text)
		{
			confirm.Play ();
			for (int i = 0; i < 10; i++) {
				if (!text.enabled) {
					text.enabled = true;
				} else {
					text.enabled = false;
				}
				yield return new WaitForSeconds (.1f);


			}
			text.enabled = true;
			yield return new WaitForSeconds (.5f);

			if (text == level1) {
				
				SceneManager.LoadScene ("track02");

			}
			if (text == level2) {
				SceneManager.LoadScene("Track03");
			}
		}
	}