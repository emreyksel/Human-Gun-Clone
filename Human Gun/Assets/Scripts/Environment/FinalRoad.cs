using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoad : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.instance.isFinish = true;
    }
}
