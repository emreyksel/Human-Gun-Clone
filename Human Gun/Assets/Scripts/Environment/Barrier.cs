using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrier : Obstacle
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (once)
        {
            once = false;
            Camera.main.DOShakeRotation(1, 2, fadeOut: true);
            Crash(-1);
        }
    }
}
