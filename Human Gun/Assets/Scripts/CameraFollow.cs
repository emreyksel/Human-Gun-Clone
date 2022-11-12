using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (!GameManager.instance.isGameOver)
        {
            transform.position = target.position + offset;
        }
    }
}
