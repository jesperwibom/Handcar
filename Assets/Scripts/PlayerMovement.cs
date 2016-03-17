using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public bool playerActive = true;
	PlayerPower playerPower;
	TimeManager tm;
	public ParticleSystem burst;


	[Header("Speed variables")]
	public float minSpeed = 0.1f;
	public float maxSpeed = 2f;
	public float slowDown = 0.02f;

	private float speed;

	[Header("Jump variables")]
	public GameObject model;
	public float jumpSwitchThreshold = 1.5f;
	public float jumpHeight = 2.5f;
	public float jumpForce = 2f; 
	public float gravity = 2.5f;

	bool grounded = true;
	bool crashed = false;

	public int floatSwitch = 0;

	[Header("Soundeffects")]
	private AudioSource flyingSound;
	private AudioSource touchGroundSound;
	private AudioSource crashSound;
	private AudioSource failSound;


	[Header("GUI variables")]
	public GameObject trackIndicator;

	private Vector3 enterPoint;
	private Vector3 exitPoint;


	public TrackSwitch trackSwitch;




	void Start(){

		flyingSound = GameObject.Find ("FlyingSound").GetComponent<AudioSource>();
		touchGroundSound = GameObject.Find ("TouchGroundSound").GetComponent<AudioSource>();
		crashSound = GameObject.Find ("CrashSound").GetComponent<AudioSource>();
		failSound = GameObject.Find ("FailSound").GetComponent<AudioSource>();

	
		var em = burst.emission;
		em.enabled = false;

		playerPower = gameObject.GetComponent<PlayerPower> ();

		enterPoint = gameObject.transform.position;
		exitPoint = new Vector3 (gameObject.transform.position.x + 1, gameObject.transform.position.y, gameObject.transform.position.z);
	}

	void Update(){
		//Check if exitPoint reached : extend exitPoint
		//Vector3 point = new Vector3(exitPoint.x+1f,exitPoint.y,exitPoint.z);
		Vector3 target = new Vector3 (exitPoint.x, exitPoint.y, transform.position.z);
		if (gameObject.transform.position == target) {
			ExtendExitPoint (2f);
		}


	}

	void FixedUpdate(){
		CorrectSpeed ();
		Move ();
		CorrectPosition ();

		switch (floatSwitch) {
		case 0:

			break;
		case -1:
			transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z + 0.01f);
			break;
		case 1:
			transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z - 0.01f);
			break;
		default:
			break;
		}
	}

	void CorrectSpeed(){
		if (speed > minSpeed) {
			if (grounded) {
				speed -= speed * slowDown;
			} else {
				speed -= speed * slowDown * 0.3f;
			}
		}
		if (speed < minSpeed) {
			speed = minSpeed;
		}
		if (speed > maxSpeed && maxSpeed != 0f) {
			speed = maxSpeed;
		}
	}

	void Move(){
		
		float step = speed * Time.deltaTime;
		Vector3 target;
		target = exitPoint;
		if (!crashed) {
			if (grounded) {
				target = exitPoint;
			} else {
				switch (floatSwitch) {
				case 0:
					target = exitPoint;
					break;
				case -1:
					target = new Vector3 (exitPoint.x, exitPoint.y, transform.position.z);
					break;
				case 1:
					target = new Vector3 (exitPoint.x, exitPoint.y, transform.position.z);
					break;
				default:
					break;
				}
			}
			transform.position = Vector3.MoveTowards (transform.position, target, step);
		}

	}

	void CorrectPosition(){

	}



	// SPEED //-------------------------//
	public void SetPathPoints(Vector3 newEnterPoint, Vector3 newExitPoint){
		enterPoint = newEnterPoint;

		float zCorrection = 0;
		if (newExitPoint.z == newEnterPoint.z) {
			zCorrection = 0;
		} else {
			if (newExitPoint.z < newEnterPoint.z) {
				zCorrection = -0.05f;
			}
			if (newExitPoint.z > newEnterPoint.z) {
				zCorrection = 0.05f;
			}
		}

		exitPoint = new Vector3(newExitPoint.x+0.05f,newExitPoint.y,newExitPoint.z-zCorrection);
		//Debug.Log ("Recieved new path points");
	}

	public void ExtendExitPoint(float extension){
		float zCorrection = 0;
		if (exitPoint.z == enterPoint.z) {
			zCorrection = 0;
		} else {
			if (exitPoint.z < enterPoint.z) {
				zCorrection = -(extension * 0.5f);
			}
			if (exitPoint.z > enterPoint.z) {
				zCorrection = (extension * 0.5f);
			}
		}
		enterPoint = exitPoint;
		exitPoint = new Vector3 (exitPoint.x + extension, exitPoint.y, (exitPoint.z + zCorrection));
		Debug.Log ("Extending exitPoint");
	}

	public Vector3 GetEnterPoint(){
		return enterPoint;
	}

	public Vector3 GetExitPoint(){
		return exitPoint;
	}

	public void ChangeSpeed(float speedChange){
		if (grounded) {
			speed += speedChange;
			playerPower.AdjustPower (speedChange);
		}
	}

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}

	public float GetSpeed(){
		return speed;
	}


	//JUMP//-------------------------//
	public bool isGrounded(){
		return grounded;
	}

	public void Jump(){
		if (grounded) {
			if (playerPower.enoughEnergy ("jump")) {
				StartCoroutine (Jumping ());
			}
		} else {
			StopAllCoroutines ();
			StartCoroutine (Landing ());
		}
	}

	IEnumerator Jumping(){
		grounded = false;
		if (flyingSound != null) {
			touchGroundSound.Play ();
			flyingSound.Play ();
		}
		if (burst != null) {
			var em = burst.emission;
			em.enabled = true;

		}
		while (model.transform.position.y < (jumpHeight - 0.15f)) {
			float step = jumpForce * Time.deltaTime * (jumpHeight - model.transform.position.y);
			model.transform.position = Vector3.MoveTowards (model.transform.position, new Vector3 (transform.position.x, transform.position.y + jumpHeight, transform.position.z), step);
			yield return null;
		}
		/*
		while (model.transform.position.y > transform.position.y) {
			float step = gravity * Time.deltaTime  * (jumpHeight - model.transform.position.y);
			model.transform.position = Vector3.MoveTowards (model.transform.position, transform.position, step);
			yield return null;
		}
			
		grounded = true;*/

	}

	IEnumerator Landing(){
		while (model.transform.position.y > transform.position.y) {
			float step = gravity * Time.deltaTime  * (jumpHeight - model.transform.position.y);
			model.transform.position = Vector3.MoveTowards (model.transform.position, transform.position, step);
			yield return null;
		}

		grounded = true;
		floatSwitch = 0;
		var em = burst.emission;
		em.enabled = false;
		if (flyingSound != null) {
			flyingSound.Stop ();
			touchGroundSound.Play ();
		}
	}




	public void SwitchLeft(){
		Debug.Log ("SWITCHING LEFT!");
		if (grounded) {
			if (playerPower.enoughEnergy ("shift")) {
				trackSwitch.Switch (-1);
			}
		} else {
			floatSwitch = -1;
		}
	}

	public void SwitchRight(){
		Debug.Log ("SWITCHING RIGHT!");
		if (grounded) {
			if (playerPower.enoughEnergy ("shift")) {
				trackSwitch.Switch (1);
			}
		} else {
			floatSwitch = 1;
		}
	}




	public void Crash(string type){

		GameObject cart = model.transform.GetChild (0).gameObject;
		Rigidbody rb = cart.GetComponent<Rigidbody> ();
		playerActive = false;

		rb.useGravity = true;
		rb.isKinematic = false;
		if (type == "ground") {
			
			StartCoroutine (GroundCrash (cart));
		}
		if (type == "wall") {
			StartCoroutine (WallCrash (cart));
		}
		cart.transform.parent = null;
	}

	IEnumerator GroundCrash(GameObject go){
		go.GetComponent<Rigidbody>().AddForce (Vector3.down * 300f);
		go.GetComponent<Rigidbody>().AddForce (Vector3.right * 100f);
		while (go.transform.position.y > -0.3f) {
			yield return null;
		
		}
		if (flyingSound.isPlaying) {
			flyingSound.Stop ();
		}
		crashSound.Play ();
		failSound.Play ();
		go.GetComponent<Rigidbody>().AddForce (Vector3.up * 400f);
		go.GetComponent<Rigidbody>().AddForce (Vector3.right * 100f);
		go.GetComponent<Rigidbody>().AddForce (Vector3.forward * 60f);
		Destroy (gameObject);
	}

	IEnumerator WallCrash(GameObject go){
		go.GetComponent<Rigidbody>().AddForce (Vector3.left * 200f);
		while (go.transform.position.y > -0.2f) {
			yield return null;

		}
		if (flyingSound.isPlaying) {
			flyingSound.Stop ();
		}
		crashSound.Play ();
		failSound.Play ();
		go.GetComponent<Rigidbody>().AddForce (Vector3.up * 140f);
		go.GetComponent<Rigidbody>().AddForce (Vector3.forward * 100f);
		Destroy (gameObject);
	}
}
