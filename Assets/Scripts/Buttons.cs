using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour{
    GameObject starting;
    GameObject joining;
    GameObject hosting;
	// Use this for initialization
	void Start () {
        starting = GameObject.Find("Starting");
        starting.SetActive(true);
        hosting = GameObject.Find("Hosting");
        hosting.SetActive(false);
        joining = GameObject.Find("Joining");
        joining.SetActive(false);

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

    public void Host() {
        joining.SetActive(false);
        hosting.SetActive(true);
        starting.SetActive(false);
        //GameObject.Find("Show Server").GetComponent<Text>().text = Channel.getInstance().getServer();
    }

    public void Join() {
        joining.SetActive(true);
        hosting.SetActive(false);
        starting.SetActive(false);
    }
    public void ConnectedServer() {
        Text t = GameObject.Find("ServerIP").GetComponent<Text>();
        string ip = t.text;
        Debug.Log(ip);
        NetworkManager.getInstance().Connect(ip, 42069);
        Channel c = NetworkManager.getInstance().getChannel();
        starting.SetActive(true);
        joining.SetActive(false);
        /*Packet p = Packet.Obtain();        
        p.buffer.PutInt(69);
        p.buffer.PutInt(12);        
        p.buffer.Flip();
        c.Send(p);
        p.Free();*/
    }
}
