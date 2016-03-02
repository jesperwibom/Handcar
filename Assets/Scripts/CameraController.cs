using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 leadingPos;
	private Vector3 secondPos;
	private Vector3 newPos;
	private float newXPos;
	private float speed = 1f;
	private GameObject player1;
	private GameObject player2;

	// Use this for initialization
	void Start () {
		Debug.Log ("player 1 is set to " + player1);
		Debug.Log ("player 2 is set to " + player2);
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
		Debug.Log ("player 1 is set to " + player1);
		Debug.Log ("player 2 is set to " + player2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){

		newPos = new Vector3 (player1.transform.position.x, transform.position.y, transform.position.z);
		Debug.Log ("new x pos is " + newPos);
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, newPos, step);
	}

}
