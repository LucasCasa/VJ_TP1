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
		if (Input.GetKey (KeyCode.A)) {
			//transform.Rotate (new Vector3 (0, 0, 3));	
			GetComponent<Rigidbody2D> ().angularVelocity = 180;
		} else if (Input.GetKey (KeyCode.D)) {
			//transform.Rotate (new Vector3 (0, 0, -3));	
			GetComponent<Rigidbody2D> ().angularVelocity = -180;
		} else {
			GetComponent<Rigidbody2D> ().angularVelocity = 0;
		}
		if (Input.GetKey (KeyCode.W)) {
			if(speed < maxSpeed)
				speed += 0.1f;
		}
		if (Input.GetKey (KeyCode.S)) {
			if(speed > 0)
				speed -= 0.1f;
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			shoot ();
		}
		GetComponent<Rigidbody2D> ().velocity = speed*transform.up;
	}
	void shoot(){
		GameObject newObj = Instantiate(GameObject.Find("Bullet")) as GameObject;
		newObj.transform.position = transform.position;
		newObj.transform.rotation = transform.rotation;
		//newObj.transform.position += 1 * newObj.transform.up;
		newObj.GetComponent<Rigidbody2D> ().velocity += new Vector2(transform.up.x*5,transform.up.y*5);
		newObj.GetComponent<Rigidbody2D> ().simulated = true;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("COlision");
	}
}
