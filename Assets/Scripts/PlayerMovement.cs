using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= speed * Time.deltaTime;
        }

        transform.position += (Vector3) moveDirection;
    }
}