using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour {

	public float amplitude;
	public float speed;
	private float tempVal;
	private Vector3 tempPos;
	// Use this for initialization
	void Start () {
		tempVal = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		tempPos = new Vector3(gameObject.transform.position.x, tempVal + amplitude * Mathf.Sin (speed * Time.time),gameObject.transform.position.z);
		transform.position = tempPos;
	}
	void FixedUpdate(){
		
	}
}
