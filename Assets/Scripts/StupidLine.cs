using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StupidLine : MonoBehaviour {
    LineRenderer ln;
    EdgeCollider2D col;
    public List<Vector2> points;
    public Transform head;
    public Head h;
    public float pointsSpacing = 0.26f;
    // Use this for initialization
    void Start () {
        ln = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updatePoints() {
        if (points.Count > 2) { 
            col.points = points.ToArray<Vector2>();
        }
        ln.positionCount = points.Count;
        for (int i = 0; i<points.Count; i++) {
            ln.SetPosition(i,points[i]);
        }
        
    }

    
}
