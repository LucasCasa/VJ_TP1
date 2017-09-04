﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollSocket : MonoBehaviour {
    public GameObject play;
    public StupidLine l;
	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(transform.gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
        Channel c = NetworkManager.getInstance().getChannel();
        if (c == null)
            return;
        Packet p = c.GetPacket();
        if (p != null) {
            MarshalingManager.Unmarshall(play, l, p.buffer); 
        }
    }
}
