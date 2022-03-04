using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIMovement : MonoBehaviour
{
    public Transform player;
    public float chaseDistance = 3;

    //an array of GameObjets
    public List<Transform> waypoints;
    //public Transform[] waypoints;
    public int waypointIndex = 0;
    public GameObject waypointPrefab;
    
    public float speed = 1.5f;
    public float minGoalDistance = 0.05f; 
     
    /*private void Update()
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
    }*/

    //array.Length == List.count

    private void Start()
    {
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
        NewWaypoint();
    }

    public void NewWaypoint()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        
         GameObject newPoint = Instantiate(waypointPrefab, new Vector2(x,y), Quaternion.identity);
         
         waypoints.Add(newPoint.transform);
    }

    public void LowestDistance()
    {
        float lowestDistance = float.PositiveInfinity;
        int lowestIndex = 0;
        float distance;
        for (int i = 0; i < waypoints.Count; i++)
        {
            distance = Vector2.Distance(player.position, waypoints[i].position);
            if (distance < lowestDistance)
            {
                lowestDistance = distance;
                lowestIndex = i;
            }
        }

        waypointIndex = lowestIndex;
    }
    
    public void WaypointUpdate()
    {
        Vector2 AIPosition = transform.position;
        
        //if we are  near the goal
        if (Vector2.Distance(AIPosition, waypoints[waypointIndex].position) < minGoalDistance)
        {
            //++ increment by 1
            //increase the value of waypointIndex up by 1
            waypointIndex++;
            
            if (waypointIndex >= waypoints.Count)
            {
                waypointIndex = 0;
            }
        }
    }

    public void AIMoveTowards(Transform goal)
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
