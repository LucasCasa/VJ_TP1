using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameLoader : MonoBehaviour {
    bool multiplayer;
    public Head player1;
    public Head player2;
    public Text p1Text;
    public Text p2Text;
	// Use this for initialization
	void Start () {
        
    }
	void Awake() {

    }
    void OnEnable() {
        Debug.Log(GameObject.Find("Mode Saver").GetComponent<ModeSaver>().singlePlayer);
        if (!GameObject.Find("Mode Saver").GetComponent<ModeSaver>().singlePlayer) {
            Debug.Log("Seteo un nuevo multi");
            GameObject.Find("Player2").SetActive(true);
            multiplayer = true;

        } else {
            Debug.Log("Seteo un nuevo single");
            GameObject.Find("Player2").SetActive(false);
            multiplayer = false;
            p1Text.text = ("Score");
            p2Text.text = "";
        }
    }
	// Update is called once per frame
	void Update () {
        if (multiplayer) {
            if(player1.score > player2.score + 10) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().player1Won = true;
                SceneManager.LoadScene("end");
            }else if(player2.score > player1.score + 10) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().player1Won = false;
                SceneManager.LoadScene("end");
            }
            if (player1.isDead) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().player1Won = false;
                SceneManager.LoadScene("end");
            }
            else if (player2.isDead) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().player1Won = true;
                SceneManager.LoadScene("end");
            }
        } else {
            if (player1.isDead) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().player1Won = false;
                SceneManager.LoadScene("end");
            }
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            if(Time.timeScale == 0) {
                Time.timeScale = 1;
            }
            else {
                Time.timeScale = 0;
            }
            
        }
	}

    void OnGUI() {
        if (multiplayer) {
            p1Text.text = ("Red " + player1.score);
            p2Text.text = ("Blue " + player2.score);
        } else {
            p1Text.text = ("Score " + player1.score);
        }
    }
}
