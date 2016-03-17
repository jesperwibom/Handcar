using UnityEngine;
using System.Collections;

public class JukeBox : MonoBehaviour {
	public AudioSource[] songs;

	int randomNo;

	void Start () {

		randomNo = Random.Range (0, 7);
		Play (randomNo);
		Debug.Log (randomNo);

	}
	public void Play(int song){
		songs [song].Play ();
	}
}
