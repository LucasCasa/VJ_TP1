using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobby : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Channel c = NetworkManager.getInstance().getChannel();
        if (c == null)
            return;
        Packet p = c.GetPacket();
        Debug.Log("List");
        if (p != null) {
            Debug.Log("Connection");
            //MarshalingManager.Unmarshall(p.buffer); 
        }
    }
}
