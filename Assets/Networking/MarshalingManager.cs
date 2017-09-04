using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshalingManager{

	
    public static void Marshall(GameObject p,Line t, Packet pa) {
        
        pa.buffer.PutQuantizedFloat(p.transform.position.x, -6.5f, 6.5f, 0.001f);
        pa.buffer.PutQuantizedFloat(p.transform.position.y, -4f, 4f, 0.001f);
        //pa.buffer.PutFloat(p.transform.position.x);
        //pa.buffer.PutFloat(p.transform.position.y);

        pa.buffer.PutFloat(p.transform.rotation.w);
        pa.buffer.PutFloat(p.transform.rotation.x);
        pa.buffer.PutFloat(p.transform.rotation.y);
        pa.buffer.PutFloat(p.transform.rotation.z);

        pa.buffer.PutBits(t.points.Count,0,5000);
        for(int i = 0; i < t.points.Count; i++) {
            pa.buffer.PutQuantizedFloat(t.points[i].x, -6.5f, 6.5f, 0.001f);
            pa.buffer.PutQuantizedFloat(t.points[i].y, -4f, 4f, 0.001f);
            //pa.buffer.PutFloat(t.points[i].x);
            //pa.buffer.PutFloat(t.points[i].y);
        }
    }

    public static void Unmarshall(GameObject p, StupidLine t, BitBuffer buff) {
        float x = buff.GetQuantizedFloat(-6.5f, 6.5f, 0.001f);
        //float x = buff.GetFloat();
        //float y = buff.GetFloat();
        float y = buff.GetQuantizedFloat(-4f, 4f, 0.001f);
        p.transform.position = new Vector3(x+1,y+1, 0);
        float w = buff.GetFloat();
        x = buff.GetFloat();
        y = buff.GetFloat();
        float z = buff.GetFloat();
        p.transform.rotation = new Quaternion(x, y, z,w);
        int count = buff.GetBits(0,5000);
        Debug.Log(count);
        t.points.Capacity = count;
        t.points.Clear();
        for (int i = 0; i < count; i++) {
            x = buff.GetQuantizedFloat(-6.5f, 6.5f, 0.001f);
            //float x = buff.GetFloat();
            //float y = buff.GetFloat();
            y = buff.GetQuantizedFloat(-4f, 4f, 0.001f);

            //Debug.Log("Posicion " + i + " x " + x + " y " + y);
            t.points.Add(new Vector2(x + 1, y+1));
        }
        t.updatePoints();
    }
}
