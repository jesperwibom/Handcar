using UnityEngine;
using System.Collections;

public class StartCameraControl : MonoBehaviour {
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (player.transform.position.x, transform.position.y, transform.position.z);
		if (player.transform.position.x >= 68) {
			player.transform.position = new Vector3(-26, player.transform.position.y, player.transform.position.z);
			transform.position = new Vector3(-26, transform.position.y, transform.position.z);
		}
	}
	void FixedUpdate(){
		
	}
}
