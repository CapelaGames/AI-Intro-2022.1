using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 3;

    //an array of GameObjets
    public Transform[] waypoints;
    public int waypointIndex = 0;

    public float speed = 1.5f;
    public float minGoalDistance = 0.05f; 
     
    private void Update()
    {
        //are we within the player chase distance
        if (Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            //Moves towards the player
            AIMoveTowards(player);
        }
        else
        {
            //Moves towards our waypoints
            WaypointUpdate();
            AIMoveTowards(waypoints[waypointIndex]);//the number is called the index
        }
    }

    private void WaypointUpdate()
    {
        Vector2 AIPosition = transform.position;
        
        //if we are  near the goal
        if (Vector2.Distance(AIPosition, waypoints[waypointIndex].position) < minGoalDistance)
        {
            //++ increment by 1
            //increase the value of waypointIndex up by 1
            waypointIndex++;
            
            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }

    private void AIMoveTowards(Transform goal)
    {
        Vector2 AIPosition = transform.position;
        
       
        //if we are not near the goal
        if (Vector2.Distance(AIPosition, goal.position) > minGoalDistance)
        {
            //direction from A to B
            // is B - A
            //method 3
            Vector2 directionToGoal = (goal.position - transform.position);
            directionToGoal.Normalize();
            transform.position += (Vector3) directionToGoal * speed * Time.deltaTime;
        }
    }
    
    
}
