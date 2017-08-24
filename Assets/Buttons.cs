using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void playScene() {
        SceneManager.LoadScene("curve");
    }

    public void playScene2Player() {
        SceneManager.LoadScene("curve");
    }
    public void playAgain() {
        SceneManager.LoadScene("curve");
    }
    public void goToMenu() {
        SceneManager.LoadScene("menu");
        Destroy(GameObject.Find("Mode Saver"));
    }
}
