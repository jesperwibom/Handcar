using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	private Vector3 leadingPos;
	private Vector3 secondPos;
	private Vector3 newPos;
	private float newXPos;
	private float speed = 1f;
	private float playerDistance;

	PlayerMovement playerMovement;

	private float originX = 0f;
	private float originY = 2f;
	private float originZ = -6f;

	public GameObject player1;
	public GameObject player2;

	// Use this for initialization
	void Start () {

		transform.position = new Vector3 (originX, originY, originZ);
		//originZ = transform.position.z;

		player1 = GameObject.FindGameObjectWithTag ("Player1");
		player2 = GameObject.FindGameObjectWithTag ("Player2");
		if (player1 != null) {
			Debug.Log ("Found player " + player1);
			playerMovement = player1.GetComponent<PlayerMovement>();
		}
		if (player2 != null) {
			Debug.Log ("Found player " + player2);
		}
		if (player1 != null && player2 != null){
			playerDistance = Mathf.Abs(player1.transform.position.x - player2.transform.position.x);
			Debug.Log ("Distance between players are " + playerDistance);
		}



	}
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){

		playerDistance = Mathf.Abs(player1.transform.position.x - player2.transform.position.x);
		if (playerDistance > 8) {
			newPos = new Vector3 (player1.transform.position.x+2f, transform.position.y, originZ-2);
			float step = playerMovement.GetSpeed() * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, newPos, step);
		}else{
			newPos = new Vector3 (player1.transform.position.x+2f, transform.position.y, transform.position.z);
			float step = playerMovement.GetSpeed() * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, newPos, step);




			/*if (playerMovement.GetSpeed () > playerMovement.maxSpeed - 1f) {
			Debug.Log ("maxspeed, zooming out");
			newPos = new Vector3 (player1.transform.position.x, transform.position.y, transform.position.z - 3f);
		} else {
			newPos = new Vector3 (player1.transform.position.x, transform.position.y, originZ);
		} */
		}

	}
}
