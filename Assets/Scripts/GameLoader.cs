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
	// Use this for initialization
	void Start () {
        paused = GameObject.Find("Paused");
        paused.SetActive(false);
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
           // GameObject.Find("Player2").SetActive(false);
            multiplayer = false;
            p1Text.text = ("Score: ");
            GameObject.Find("BlueScore").SetActive(false);
        }
        GameObject.Find("Audio Source").GetComponent<AudioSource>().Play();
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
        if(player1.score > player2.score + 10 || player2.isDead) {
            p1 = true;
        }
        if(player2.score > player1.score + 10 || player1.isDead){
            p2 = true;
        }
        if (p2 || p1) {
            if (!p1) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().whoWon = 2;
            } else if (!p2) {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().whoWon = 1;
            } else {
                GameObject.Find("Mode Saver").GetComponent<ModeSaver>().whoWon = 0;
            }
            GameObject.Find("Audio Source").GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("end");
        }
    }
    private void FixedUpdate() {
        send++;
        if (send == 1) {
            Packet p = Packet.Obtain();
            MarshalingManager.Marshall(p1, t, p);
            p.buffer.Flip();
            NetworkManager.getInstance().getChannel().Send(p);
            p.Free();
            send = 0;
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
