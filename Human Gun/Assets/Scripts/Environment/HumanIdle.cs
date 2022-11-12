using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanIdle : MonoBehaviour
{
    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        GunType.instance.HumanCounter(1);
        gameObject.SetActive(false);
    }
}
