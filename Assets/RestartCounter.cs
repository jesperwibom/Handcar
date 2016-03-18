using UnityEngine;
using System.Collections;

public class RestartCounter : MonoBehaviour {

	public int count = 0;

	void Start(){
		DontDestroyOnLoad (gameObject);
	}

}
