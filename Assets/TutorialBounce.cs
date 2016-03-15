using UnityEngine;
using System.Collections;

public class TutorialBounce : MonoBehaviour {

	public float amplitude;
	public float speed;
	private float tempVal;
	private float tempValX;
	private float tempValY;
	private float tempValZ;
	private Vector3 tempPos;
	public GameObject camera;

	// Use this for initialization
	void Start () {
		tempVal = gameObject.transform.localScale.x;
		tempValX = gameObject.transform.localScale.x;
		tempValY = gameObject.transform.localScale.y;
		tempValZ = gameObject.transform.localScale.z;

	}

	// Update is called once per frame
	void Update () {
		

	}
	void FixedUpdate(){
		tempPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		gameObject.transform.localScale = new Vector3 ((tempValX + amplitude * Mathf.Sin (speed * Time.time))*0.5f, tempValY + amplitude * Mathf.Sin (speed * Time.time), tempValZ + amplitude * Mathf.Sin (speed * Time.time));
		transform.position = tempPos;
		transform.position = new Vector3 (camera.transform.position.x-5f, transform.position.y, transform.position.z);
	}
}
