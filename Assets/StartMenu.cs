using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{


	private Text pointer1;
	private Text pointer2;
	private Text pointer3;
	private Text level1;
	private Text level2;
	private Text level3;
	private AudioSource sound;
	private AudioSource confirm;
	private bool l1 = true;
	private bool l2 = false;
	private bool l3 = false;
	private int levelSelect = 1;

	// Use this for initialization
	void Start ()
	{

		pointer1 = GameObject.Find ("Pointer1").GetComponent<Text> ();
		pointer2 = GameObject.Find ("Pointer2").GetComponent<Text> ();
		level1 = GameObject.Find ("Level1").GetComponent<Text> ();
		level2 = GameObject.Find ("Level2").GetComponent<Text> ();
		level3 = GameObject.Find ("Level3").GetComponent<Text> ();
		pointer3 = GameObject.Find ("Pointer3").GetComponent<Text> ();
		pointer1.enabled = true;
		pointer3.enabled = false;
		pointer2.enabled = false;
		sound = GameObject.Find ("MenuSound").GetComponent<AudioSource> ();
		confirm = GameObject.Find ("ConfirmSound").GetComponent<AudioSource> ();
	}

	void Update ()
	{
		if (Input.GetKeyDown ("down")) {
			Down ();
		}
			
		if (Input.GetKeyDown ("e")) {
			Select ();
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
				
			SceneManager.LoadScene ("track01");

		}
		if (text == level2) {
			SceneManager.LoadScene ("Track02");
		}
		if (text == level3) {
			SceneManager.LoadScene ("Track03");
		}
	}

	public void Down(){
		if (pointer1.enabled) {
			levelSelect = 2;
			pointer2.enabled = true;
			pointer1.enabled = false;
			pointer3.enabled = false;
			confirm.Play ();
		} else if (pointer2.enabled) {
			levelSelect = 3;
			pointer2.enabled = false;
			pointer1.enabled = false;
			pointer3.enabled = true;
			confirm.Play ();
		} else {
			if (pointer3.enabled) {
				levelSelect = 1;
				pointer2.enabled = false;
				pointer1.enabled = true;
				pointer3.enabled = false;
				confirm.Play ();
			}
		}
	}

	public void Select(){
		if (pointer1.enabled == true) {
			StartCoroutine (Go (level1));
		}
		if (pointer2.enabled) {
			StartCoroutine (Go (level2));
		}
		if (pointer3.enabled) {
			StartCoroutine (Go (level3));
		}
	}
}