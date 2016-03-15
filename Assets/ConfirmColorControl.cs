using UnityEngine;
using System.Collections;

public class ConfirmColorControl : MonoBehaviour {
	private GameObject camera;
	public GameObject confirmTutorial;

	// Use this for initialization
	void Start () {
		camera = GameObject.FindGameObjectWithTag ("Camera");
		transform.position = new Vector3 (0, 2.6f, 0);

	}

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (camera.transform.position.x+5f, transform.position.y, transform.position.z);
		if (Input.GetKeyDown ("down") || (Input.GetKeyDown("up"))) {
			
			Destroy (gameObject);		
		}
	}

}
