using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    protected bool once = true;

    [System.Obsolete]
    protected void Crash(int counter)
    {
        GunType.instance.HumanCounter(counter);
    }
}
