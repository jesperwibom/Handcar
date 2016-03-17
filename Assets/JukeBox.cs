using UnityEngine;
using System.Collections;

public class JukeBox : MonoBehaviour {
	public AudioSource[] songs;

	int randomNo;

	void Start () {

		Play(Random.Range (0, 7));


	}
	public void Play(int song){
		songs [song].Play ();
	}
}
