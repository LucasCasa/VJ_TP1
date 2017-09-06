using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour {
    public Text text;
	// Use this for initialization
	void Start () {
        ModeSaver ms = GameObject.Find("Mode Saver").GetComponent<ModeSaver>();
        if (ms.singlePlayer) {
            text.text = "FINAL SCORE\n" + ms.score;
            text.fontSize = 72;
        } else {
            switch(ms.whoWon) {
                case 1:
                    text.text = "Red wins";
                    text.color = Color.red;
                    break;
                case 2:
                    text.text = "Blue wins";
                    text.color = Color.cyan;
                    break;
                case 0:
                    text.text = "Draw";
                    text.color = Color.white;
                    break;

            }
        }
	    
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
