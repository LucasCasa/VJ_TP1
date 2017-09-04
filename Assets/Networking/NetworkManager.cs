using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager{
    private static NetworkManager self = new NetworkManager();
    private Channel c;

    private NetworkManager() {

    }

    public static NetworkManager getInstance() {
        return self;
    }

    internal void Connect(string ip, int v) {
        c = new Channel(ip, v);
    }

    internal Channel getChannel() {
        return c;
    }
    public void Close() {
        c.abortThread();
    }

    internal void Send(Vector3 position, Quaternion rotation) {
        if (c != null) {
            Packet p = Packet.Obtain();
            p.buffer.PutFloat(position.x);
            p.buffer.PutFloat(position.y);
            p.buffer.PutFloat(position.z);
            p.buffer.PutFloat(rotation.w);
            p.buffer.PutFloat(rotation.x);
            p.buffer.PutFloat(rotation.y);
            p.buffer.PutFloat(rotation.z);
            p.buffer.Flip();
            c.Send(p);
            p.Free();
        }
    }

    internal void Listen(int port) {
        c = new Channel(null , port);
    }
}
