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
    
    //public GameObject[] position;
    public List<GameObject> position;
    public int positionIndex = 0;
    public GameObject wayPointPrefab;
    
        
    public float speed = 1.5f;
    public float minGoalDistance = 0.05f;

    /*private void Update()
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
    }*/

    private void Start()
    {
        NewWayPoint();
        NewWayPoint();
        NewWayPoint();
        NewWayPoint();


        RemoveCurrentWayPoint();
        RemoveCurrentWayPoint();
    }

    public void RemoveCurrentWayPoint()
    {
        //method 1 give list.remove a gameobject to remove from the list
        //GameObject current = position[positionIndex];
        //position.Remove( current);
       // Destroy(current);
        
        //method 2 give list.removeat an index to remove from the list
       // GameObject current = position[positionIndex];
        //position.RemoveAt(positionIndex);
        //Destroy(current);
    }

    public void NewWayPoint()
    {
        float x = Random.Range(-5f, 5f);
        float y = Random.Range(-5f, 5f);
        
        GameObject newPoint = Instantiate(wayPointPrefab, new Vector2(x,y), Quaternion.identity);
        
        position.Add(newPoint);
        

    }

    public void FindClosestWaypoint()
    {
        float nearest = float.PositiveInfinity;
        int nearestIndex = 0;

        for (int i = 0; i < position.Count; i++)
        {
            float distance = Vector2.Distance(transform.position, position[i].transform.position);
            if (distance < nearest)
            {
                nearest = distance;
                nearestIndex = i;
            }
        }

        positionIndex = nearestIndex;
    }
    

    public bool IsPlayerInRange()
    {
        return Vector2.Distance(transform.position, player.position) < chaseDistance;
    }
    

    public void WaypointUpdate()
    {
        if (Vector2.Distance(transform.position, position[positionIndex].transform.position) < minGoalDistance)
        {
            positionIndex++;
            
            if (positionIndex >= position.Count)
            {
                positionIndex = 0;
            }
        }
    }
    
    public void AIMoveTowards(Transform goal)
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