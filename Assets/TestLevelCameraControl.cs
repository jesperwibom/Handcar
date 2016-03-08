using UnityEngine;
using System.Collections;

public class TestLevelCameraControl : MonoBehaviour {
	public GameObject playerObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (playerObject.transform.position.x+2f, transform.position.y, playerObject.transform.position.z-15f);
	}
}
