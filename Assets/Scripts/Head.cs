using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Head : MonoBehaviour {
	public float speed = 1f;
	public float rotationSpeed = 250f;
	public string inputAxes = "Horizontal";
	float horizontal = 0f;
    public bool isDead = false;
    public int size = 10;
    public int score = 0;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		horizontal = -Input.GetAxisRaw (inputAxes);
        transform.Translate(Vector3.up * speed * Time.deltaTime, Space.Self);
        transform.Rotate(horizontal * Vector3.forward * rotationSpeed * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D other){
        if (other.name == "Food") {
            size += 5;
            score++;
        }else if (other.tag == "PowerUp")
        {
      
        }else {
            isDead = true;
        }
	}
}
