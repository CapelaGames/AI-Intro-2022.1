using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    //create variable
    //place data in variable
    //use variable
    public GameObject position0;
    public GameObject position1;
    
    
    private void Update()
    {
        Vector2 AIPosition = transform.position;
        
        /*transform.position = Vector2.MoveTowards(transform.position, 
                                            position0.transform.position,
                                                         Time.deltaTime);*/

        //method 1
        /*if(transform.position.x < position0.transform.position.x)
        {
            //Move right
            AIPosition.x += (1 * Time.deltaTime);
            transform.position = AIPosition;
        }
        else
        {
            //Move Left
            AIPosition.x -= (1 * Time.deltaTime);
            transform.position = AIPosition;
        }

        //method 2
        if (transform.position.y < position0.transform.position.y)
        {
            transform.position += (Vector3) Vector2.up * 1 * Time.deltaTime;
        }
        else
        {
            transform.position -= (Vector3) Vector2.up * 1 * Time.deltaTime;
        }*/
        
        //direction from A to B
        // is B - A

        //method 3
        Vector2 directionToPos0 = (position0.transform.position - transform.position);
        directionToPos0.Normalize();
        transform.position += (Vector3) directionToPos0 * 1 * Time.deltaTime;
    }

    
}
