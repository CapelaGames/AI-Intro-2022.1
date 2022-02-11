using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    //create the variable
    //place data in the variable
    //use the variable
    public GameObject position0;
    public GameObject position1;
    
    private void Update()
    {
        /*// transform.position = Vector2.MoveTowards(transform.position,
        //                                     position0.transform.position, 
        //                                                 Time.deltaTime);
        Vector2 AIPosition = transform.position;
        //Method 1
        //if cube is on the left
        if(transform.position.x < position0.transform.position.x)
        {
            //do things in here if the if statement is true
            //move right
            AIPosition.x += (1 * Time.deltaTime);
        }
        else
        {
            //move left
            AIPosition.x -= (1 * Time.deltaTime);
        }
        transform.position = AIPosition;
        
        
        //method 2
        if (transform.position.y < position0.transform.position.y)
        {
            transform.position += (Vector3) Vector2.up * 1 * Time.deltaTime;
        }
        else
        {
            transform.position -= (Vector3) Vector2.up * 1 * Time.deltaTime;
        }*/
        
        
        //method 3
        //direction from A to B
        // is B - A
        //X = B - A
        
        Vector2 directionToPos0 = (position0.transform.position - transform.position);
        directionToPos0.Normalize();
        transform.position += (Vector3) directionToPos0 * 1 * Time.deltaTime;

    }
}