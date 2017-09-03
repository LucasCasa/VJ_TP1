using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour {
	LineRenderer ln;
	EdgeCollider2D col;
	public List<Vector2> points;
	public Transform head;
    public Head h;
	public float pointsSpacing = 0.26f;
	// Use this for initialization
	void Start () {
		ln = GetComponent<LineRenderer> ();
		col = GetComponent<EdgeCollider2D> ();
		points = new List<Vector2> ();
	}

	// Update is called once per frame
	void Update () {
		if (points.Count == 0 || Vector3.Distance (points.Last (), head.position) > pointsSpacing) {
			setPoint ();
		}
	}

	void setPoint(){
        if (points.Count > 2)
            col.points = points.ToArray<Vector2>();

        points.Add(head.position);
        if (points.Count > h.size) {
            ln.positionCount = points.Count-1;
            for (int i = 0; i < points.Count-1; i++) {
                ln.SetPosition(i, points[i]);
            }
            points.RemoveAt(0);
        } else {
            ln.positionCount = points.Count;
            ln.SetPosition(points.Count - 1, head.position);
        }
    }
}
