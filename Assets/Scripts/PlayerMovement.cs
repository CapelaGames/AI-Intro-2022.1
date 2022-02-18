using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 moveDirection = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            moveDirection.y++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDirection.y--; 
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x--;
        }
        moveDirection.Normalize();
        moveDirection *= (speed * Time.deltaTime);
        
        transform.position += (Vector3) moveDirection;
    }
}
