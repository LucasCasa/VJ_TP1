using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeSaver : MonoBehaviour {
    public bool singlePlayer = false;
    public bool player1Won = false;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setSinglePlayer() {
        Debug.Log("Seteo single");
        singlePlayer = true;
        Debug.Log(singlePlayer);
    }
    public void setMultiPlayer() {
        Debug.Log("Seteo Multi");
        singlePlayer = false;
        Debug.Log(singlePlayer);
    }

    private void OnApplicationQuit() {
        NetworkManager.getInstance().Close();
    }
}
