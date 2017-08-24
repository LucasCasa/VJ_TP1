using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        ModeSaver ms = GameObject.Find("Mode Saver").GetComponent<ModeSaver>();
        if (!ms.singlePlayer) {
            if (ms.player1Won) {
                text.text = "Red wins";
            }
            else {
                text.text = "Blue wins";

            }
        } else {
            text.text = "Loser";
        }
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
