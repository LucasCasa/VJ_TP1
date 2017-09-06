using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {
    bool multiplayer;
    public Head player1;
    public Head player2;
    public GameObject p1;
    public Line t;
    public Text p1Text;
    public Text p2Text;
    public GameObject paused;
    public int send = 0;
    public ModeSaver ms;
	// Use this for initialization
	void Start () {
        paused = GameObject.Find("Paused");
        paused.SetActive(false);
       
    }
	void Awake() {

    }
    void OnEnable() {
        ms = GameObject.Find("Mode Saver").GetComponent<ModeSaver>();
        if (ms.singlePlayer) {
            GameObject.Find("Player2").SetActive(false);
            multiplayer = false;
            p1Text.text = ("Score: ");
            GameObject.Find("BlueScore").SetActive(false);
        } else {
            GameObject.Find("Player2").SetActive(true);
            multiplayer = true;
        }
        GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();
      
    }
	// Update is called once per frame
	void Update () {
        CheckEnd();
        if (Input.GetKeyDown(KeyCode.P)) {
            if(Time.timeScale == 0) {
                Time.timeScale = 1;
                paused.SetActive(false);
            } else {
                Time.timeScale = 0;
                paused.SetActive(true);
            }
            
        }
        
	}

    void CheckEnd() {
        bool p1 = false;
        bool p2 = false;
        if((multiplayer && player1.score > player2.score + 10) || player2.isDead) {
            p1 = true;
        }
        if((multiplayer && player2.score > player1.score + 10) || player1.isDead){
            p2 = true;
        }
        if (p2 || p1) {
            if (!p1) {
                ms.whoWon = 2;
                ms.score = player1.score;
            } else if (!p2) {
                ms.whoWon = 1;
            } else {
                ms.whoWon = 0;
            }
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("end");
        }
    }

    void OnGUI() {
        if (multiplayer) {
            p1Text.text = ("Red: " + player1.score);
            p2Text.text = ("Blue: " + player2.score);
        } else {
            p1Text.text = ("Score: " + player1.score);
        }
    }
}
