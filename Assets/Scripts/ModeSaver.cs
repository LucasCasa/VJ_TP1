using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSaver : MonoBehaviour {
    public bool singlePlayer = false;
    public int whoWon = 0;
    public int score;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSinglePlayer() {
        singlePlayer = true;
    }
    public void setMultiPlayer() {
        singlePlayer = false;
    }
}
