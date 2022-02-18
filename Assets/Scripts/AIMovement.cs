using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 3;
    
    public GameObject[] position;
    public int positionIndex = 0;
    
        
    public float speed = 1.5f;
    public float minGoalDistance = 0.05f;

    private void Update()
    {
        //are we within the player chase distance?
        if (Vector2.Distance(transform.position, player.position) < chaseDistance)
        {
            //move towards player
            AIMoveTowards(player);
        }
        else
        {
            WaypointUpdate();
            //move towards our waypoints
            AIMoveTowards(position[positionIndex].transform);
        }

    }

    private void WaypointUpdate()
    {
        if (Vector2.Distance(transform.position, position[positionIndex].transform.position) < minGoalDistance)
        {
            positionIndex++;
            
            if (positionIndex >= position.Length)
            {
                positionIndex = 0;
            }
        }
    }
    
    private void AIMoveTowards(Transform goal)
    {
        //if we are not near the goal
        if (Vector2.Distance(transform.position, goal.position) > minGoalDistance)
        {
            //direction from A to B
            // is B - A
            // X = B - A
            Vector2 directionToGoal = (goal.position - transform.position);
            directionToGoal.Normalize();
            transform.position += (Vector3) directionToGoal * speed * Time.deltaTime;
        }
    }
    
}