using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.value*10 - 5, Random.value*10 - 5, 10.0f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        transform.position = new Vector3(Random.value*10 - 5, Random.value*10 -5 , 10.0f);
    }
}
