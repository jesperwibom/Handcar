using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 leadingPos;
	private Vector3 secondPos;
	private Vector3 newPos;
	private GameObject player1;
	private GameObject player2;

	// Use this for initialization
	void Start () {
		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
