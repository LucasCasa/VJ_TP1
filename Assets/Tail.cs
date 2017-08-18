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
			transform.position += moveSpeed * Time.deltaTime * (p.transform.position - transform.position);
		}
		//transform.position += moveSpeed * Time.deltaTime * transform.right;
	}

}
