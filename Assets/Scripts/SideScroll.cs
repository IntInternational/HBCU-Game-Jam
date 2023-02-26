using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{
    Rigidbody2D body;

    public GameObject mover;

    public float speed = 2.0f;
    public float nextXPos = 0f;

    public bool moving = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        nextXPos = transform.position.x;

        Debug.Log(nextXPos);
    }

    void Update()
    {
        if (Input.GetKey("f"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if (Input.GetKey("h"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (moving)
        {
            moveToPosition(nextXPos);
            // Debug.Log(nextXPos);
        }
    }

    public void moveToPosition(float xPos)
    {
        if (transform.position.x <= xPos)
            transform.position += Vector3.right * speed * Time.deltaTime;
        if (transform.position.x == xPos)
            moving = false;
    }
}
