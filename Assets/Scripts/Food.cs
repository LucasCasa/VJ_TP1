using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {
    public float maxX;
    public float minX;
    public float minY;
    public float maxY;
    public AudioSource audioSource;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(Random.value*(maxX-minX)+minX,Random.value*(maxY - minY) + minY,10.0f);
        audioSource = gameObject.GetComponent <AudioSource>();
        //Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Random.value*Screen.width*0.8f,Random.value*Screen.height*0.8f, 10.0f));
        //transform.position = v;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        audioSource.Play();
        transform.position = new Vector3(Random.value * (maxX - minX) + minX, Random.value * (maxY - minY) + minY, 10.0f);
        //Vector3 v = Camera.main.ScreenToWorldPoint(new Vector3(Random.value*Screen.width*0.8f, Random.value*Screen.height*0.8f, 10.0f));
        //transform.position = v;
    }
}
