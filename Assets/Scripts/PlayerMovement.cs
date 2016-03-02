using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float minSpeed = 0.1f;
	public float maxSpeed = 2f;
	public float slowDown = 0.02f;
	public float gravity = 0.5f;

	// public ModelManager model;

	private float speed;

	private Vector3 enterPoint;
	private Vector3 exitPoint;

	bool grounded = true;

	void Start(){
		enterPoint = gameObject.transform.position;
		exitPoint = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
	}

	void Update(){
		//Check if exitPoint reached : extend exitPoint on x-axis with 1 unit
		if (gameObject.transform.position == exitPoint) {
			ExtendExitPoint (1f);
		}
	}

	void FixedUpdate(){
		CorrectSpeed ();
		Move ();
		CorrectPosition ();
	}

	void Move(){
		
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, exitPoint, step);

	}

	void CorrectPosition(){

	}

	void CorrectSpeed(){
		if (speed > minSpeed) {
			speed -= speed * slowDown;
		}
		if (speed < minSpeed) {
			speed = minSpeed;
		}
		if (speed > maxSpeed && maxSpeed != 0f) {
			speed = maxSpeed;
		}
	}



	public bool isGrounded(){
		return grounded;
	}

	public void SetPathPoints(Vector3 newEnterPoint, Vector3 newExitPoint){
		enterPoint = newEnterPoint;
		exitPoint = newExitPoint;
		Debug.Log ("Recieved new path points");
	}

	public void ExtendExitPoint(float extension){
		enterPoint = exitPoint;
		exitPoint = new Vector3 (exitPoint.x + extension, exitPoint.y, exitPoint.z);
		Debug.Log ("Extending exitPoint");
	}

	public Vector3 GetEnterPoint(){
		return enterPoint;
	}

	public Vector3 GetExitPoint(){
		return exitPoint;
	}

	public void ChangeSpeed(float speedChange){
		speed += speedChange;
	}

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}

	public float GetSpeed(){
		return speed;
	}

	public void Jump(){

	}

}
