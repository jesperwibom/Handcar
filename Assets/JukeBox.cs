using UnityEngine;
using System.Collections;

public class JukeBox : MonoBehaviour {
	public AudioSource[] songs;


	void Start () {

		Play(Random.Range (0, 6));

	}
	public void Play(int song){
		songs [song].Play ();
	}
}
