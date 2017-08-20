using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour {
	float speed = 0;
	float maxSpeed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.A)){
			transform.Rotate (new Vector3 (0, 0, 3));	
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Rotate (new Vector3 (0, 0, -3));	
		}
		if (Input.GetKey (KeyCode.W)) {
			if(speed < maxSpeed)
				speed += 0.1f;
		}
		if (Input.GetKey (KeyCode.S)) {
			if(speed > 0)
				speed -= 0.1f;
		}
		transform.position += speed * Time.deltaTime * transform.up;
	}

}
