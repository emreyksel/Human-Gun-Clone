using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    private Transform moneyImage;

    private void Awake()
    {
        moneyImage = GameObject.FindGameObjectWithTag("MoneyImage").transform;
    }


    private void OnTriggerEnter(Collider other)
    {
        GameObject cloneMoney = ObjectPool.instance.GetPooledObject(0);
        cloneMoney.transform.SetParent(moneyImage);
        cloneMoney.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        gameObject.SetActive(false);
    }
}
