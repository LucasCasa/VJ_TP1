using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour {
	public int moveSpeed;
	public double acum = 0;
	public bool original = true;
	GameObject Last;
	private SpriteRenderer sr;
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
		transform.position += moveSpeed * Time.deltaTime * transform.up;
		acum += Time.deltaTime;
		Text textObject = GameObject.Find("Timer").GetComponent<Text>();
		textObject.text = acum.ToString().Remove(6);
		if (acum > 3 && original) {
			acum = 0;
			GameObject newObj = Instantiate(GameObject.Find("Tail")) as GameObject;
			if (Last == null)
				newObj.transform.position = transform.position - transform.up;
			else
				newObj.transform.position = Last.transform.position;
			
			if (Last == null) {
				((Tail)newObj.GetComponent ("Tail")).p = gameObject;
			} else {
				((Tail)newObj.GetComponent ("Tail")).p = Last;
			}
			Last = newObj;
		}

	}
}
