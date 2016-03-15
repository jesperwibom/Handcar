using UnityEngine;
using System.Collections;

public class ColorTutorialControl : MonoBehaviour {
	private GameObject player;
	public GameObject confirmTutorial;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player1");
		transform.position = new Vector3 (0, 2.6f, 0);

	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x-5f, transform.position.y, transform.position.z);
		if (Input.GetKeyDown ("down") || (Input.GetKeyDown("up"))) {
			GameObject nextTutorial = (GameObject)Instantiate(confirmTutorial);
			Destroy (gameObject);		
		}
	}

}
