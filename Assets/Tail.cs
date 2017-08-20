using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour {
	public GameObject p;
	public int moveSpeed = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (p != null) {
			//Debug.Log (p);
			//Debug.Log (transform.position);
			float dist = Vector3.Distance (transform.position, p.transform.position);
			float thisSize = GetComponent<CircleCollider2D> ().bounds.size.x;
			float otherSize = p.GetComponent<CircleCollider2D>().bounds.size.x;
			if (dist > 0.9)
				transform.position = getDirection (moveSpeed * Time.deltaTime);
			else {
				//Debug.Log (thisSize);
				//Debug.Log (dist);

			}
		}
		//transform.position += moveSpeed * Time.deltaTime * transform.right;
	}
	void OnTriggerEnter2D(Collider2D other) {
		//Destroy(other.gameObject);
		Debug.Log("COlision");
	}
	public Vector3 getDirection(float mag){
		return Vector3.MoveTowards (transform.position, p.transform.position,mag);
	}
}
