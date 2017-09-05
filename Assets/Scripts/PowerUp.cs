using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour {
    public float maxX;
    public float minX;
    public float minY;
    public float maxY;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(Random.value * (maxX - minX) + minX, Random.value * (maxY - minY) + minY, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
        if (other.gameObject.tag == "Head")
        {
            Effect(other.gameObject);
        }
    }

    public abstract void Effect(GameObject other);
}
