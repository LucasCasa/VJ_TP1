using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {
	float timeSincelast = 0;
	float w = 0;
	float h = 0;
	// Use this for initialization
	void Start () {
		w = Camera.current.pixelWidth;
		h = Camera.current.pixelHeight;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("Hola");
		timeSincelast+= Time.deltaTime;
		if (timeSincelast > (Random.value * 4)) {
			timeSincelast = 0;
			float x = 0;
			float y = 0;
			GameObject newObj = Instantiate(GameObject.Find("Asteroid")) as GameObject;
			float rand = Random.value;
			Vector3 v3Pos;
			Debug.Log (rand);
			if (rand < 0.25f) { //ARRIBA
				//y = w + 5;
				//x = Random.value * h;
				v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, 1.1f, 10.0f));
				newObj.GetComponent<Asteroid>().direction = new Vector2 (0, -1);
			} else if (rand < 0.5f) { // ABAJO
				v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (Random.value, -0.1f, 10.0f));
				newObj.GetComponent<Asteroid>().direction = new Vector2 (0, 1);
			} else if (rand < 0.75f) { //DERECHA
				v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (1.1f,Random.value, 10.0f));
				newObj.GetComponent<Asteroid>().direction = new Vector2 (-1,0);
			} else { //IZQUIERDA
				v3Pos = Camera.main.ViewportToWorldPoint (new Vector3 (-0.1f,Random.value, 10.0f));
				newObj.GetComponent<Asteroid>().direction = new Vector2 (1, 0);
			}
			newObj.transform.position = v3Pos;
		}
	}
}
