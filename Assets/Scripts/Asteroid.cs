using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {
	float speed = 3;
	public Vector2 direction;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D> ().velocity = speed*direction;
		GetComponent<Rigidbody2D> ().angularVelocity = 60;
	}
	
	// Update is called once per frame
	void Update () {
		//transform.Translate( * Time.deltaTime*direction,Space.World);
		//transform.Rotate(new Vector3(0,0,1));
	}
}
