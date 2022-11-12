using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Vector3 firstTouchPosition;
    private Vector3 curTouchPosition;
    [SerializeField] private float sensitivityMultiplier = 0.01f;
    private float finalTouchX;
    private float xBound = 1.75f;
    public float speed;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!GameManager.instance.isGameStart || GameManager.instance.isGameOver)
            return;

        Move();
    }

    private void FixedUpdate()
    {
        if (!GameManager.instance.isGameStart || GameManager.instance.isGameOver)
            return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void Move()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            curTouchPosition = Input.mousePosition;

            Vector2 touchDelta = (curTouchPosition - firstTouchPosition);

            finalTouchX = (transform.position.x + (touchDelta.x * sensitivityMultiplier));
            finalTouchX = Mathf.Clamp(finalTouchX, -xBound, xBound);

            transform.position = new Vector3(finalTouchX, transform.position.y, transform.position.z);

            firstTouchPosition = Input.mousePosition;
        }
    }
}
