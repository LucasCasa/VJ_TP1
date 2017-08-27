using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollSocket : MonoBehaviour {

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
            float x = p.buffer.GetFloat();
            float y = p.buffer.GetFloat();
            float w = p.buffer.GetFloat();
            float xr = p.buffer.GetFloat();
            float yr = p.buffer.GetFloat();
            float z = p.buffer.GetFloat();
            Debug.Log("Position: (" + x +", " + y +")");
            Debug.Log("Position: (" + w +", " + xr+")");
        }
    }
}
