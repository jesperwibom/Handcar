using UnityEngine;
using System.Collections;

public class PlayerSound : MonoBehaviour {

	AudioSource horn;

	void Start () {
		horn = gameObject.GetComponent<AudioSource>();
	}

	public void Honk(){
		horn.Play();
	}

}
