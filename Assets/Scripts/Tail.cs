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
			Transform newPos = p.GetComponent<Transform> ();
			//float thisSize = GetComponent<CircleCollider2D> ().bounds.size.x;
			//float otherSize = p.GetComponent<CircleCollider2D>().bounds.size.x;
			float t = Time.deltaTime * dist / 0.8f * moveSpeed;
			if (t > 0.4f)
				t = 0.4f;
			
			transform.position = Vector3.Slerp (transform.position, newPos.position, t);
			transform.rotation = Quaternion.Slerp (transform.rotation, newPos.rotation, t);
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
