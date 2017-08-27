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
        /*LineRenderer lr = GameObject.Find("Wall").GetComponent<LineRenderer>();
        lr.positionCount = 5;
        float min = Mathf.Min(Screen.width, Screen.height);
        float top = 0.8f*min;
        float bottom = 0.2f * min;
        List<Vector2> s = new List<Vector2>();
        s.Add(new Vector2(top, top));
        s.Add(new Vector2(top, bottom));
        s.Add(new Vector2(bottom, bottom));
        s.Add(new Vector2(bottom, top));
        s.Add(new Vector2(top, top));
        lr.SetPosition(0, Camera.main.ScreenToWorldPoint(s[0]));
        lr.SetPosition(1, Camera.main.ScreenToWorldPoint(s[1]));
        lr.SetPosition(2, Camera.main.ScreenToWorldPoint(s[2]));
        lr.SetPosition(3, Camera.main.ScreenToWorldPoint(s[3]));
        lr.SetPosition(4, Camera.main.ScreenToWorldPoint(s[4]));
        EdgeCollider2D ed2d = GameObject.Find("Wall").GetComponent<EdgeCollider2D>();
        Vector2[] vs = s.ToArray();
        ed2d.points = vs;
        Debug.Log("Arena Set");*/
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
