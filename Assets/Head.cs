using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : MonoBehaviour {
	public float speed = 3f;
	public float rotationSpeed = 250f;
	public string inputAxes = "Horizontal";
	float horizontal = 0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		horizontal = -Input.GetAxisRaw (inputAxes);
	}

	void FixedUpdate(){
		transform.Translate (Vector3.up * speed* Time.fixedDeltaTime, Space.Self);
		transform.Rotate (horizontal * Vector3.forward * rotationSpeed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("CHOQUE");
	}
}
