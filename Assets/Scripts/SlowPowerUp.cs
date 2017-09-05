using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPowerUp : PowerUp {

    public float speedFactor = 1.5f;
    public float duration = 7f;
    private Head h;

    public override void Effect(GameObject other)
    {
        h = other.GetComponent<Head>();
        h.speed /= speedFactor;
        Invoke("EndPowerUp", duration);
    }

    public void EndPowerUp()
    {
        h.speed *= speedFactor;
        Destroy(this);
    }
}
