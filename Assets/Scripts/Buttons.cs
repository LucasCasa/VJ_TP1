using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{
    GameObject starting;
	// Use this for initialization
	void Start () {
        /*starting = GameObject.Find("Starting");
        if (starting != null) {
            starting.SetActive(true);
        }*/

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayGame() {
        SceneManager.LoadScene("curve");
    }
    public void GoToMenu() {
        SceneManager.LoadScene("menu");
        Destroy(GameObject.Find("Mode Saver"));
    }

    public void Quit() {
        Application.Quit();
    }
}
