using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float minSpeed = 0.1;
	public float maxSpeed = 2f;
	public float slowDown = 0.02;

	public float gravity = 0.5f;

	// public ModelManager model;

	private float speed;

	private Vector3 enterPoint;
	private Vector3 exitPoint;


	bool grounded = true;

	void Update(){
		if (speed > minSpeed) {
			speed -= speed * slowDown;
		}
		if (speed < minSpeed) {
			speed = minSpeed;
		}
	}

	void FixedUpdate(){
		Move ();
		CorrectPosition ();
	}

	void Move(){
		/*
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, exitPoint, step);
		*/
	}

	void CorrectPosition(){

	}





	public bool isGrounded(){
		return grounded;
	}

	public void SetPathPoints(Transform newEnterPoint, Transform newExitPoint){
		enterPoint = newEnterPoint;
		exitPoint = newExitPoint;
	}

	public void ExtendExitPoint(){

	}

	public void IncreaseSpeed(float speedIncrease){
		speed += speedIncrease;
		if (speed > maxSpeed) {
			speed = maxSpeed;
		}
	}

}
