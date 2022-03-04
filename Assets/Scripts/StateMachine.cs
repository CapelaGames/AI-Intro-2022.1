using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class StateMachine : MonoBehaviour
{
    //comma separated list of identifiers 
    public enum State
    {
        Attack,
        Defence,
        RunAway,
        BerryPicking,
    }
    

    public State currentState;
    public AIMovement aiMovement;
    
    private void Start()
    {
        aiMovement = GetComponent<AIMovement>();
        
        NextState();
    }

    private void NextState()
    {
        //runs one of the cases that matches the value (in this example the value is currentState)
        switch (currentState)
        {
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Defence:
                StartCoroutine(DefenceState());
                break;
            case State.RunAway:
                StartCoroutine(RunAwayState());
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
        } 
    }


    //Coroutine is a special method that can be paused and returned to later
    private IEnumerator AttackState()
    {
        Debug.Log("Attack: Enter");
        
        
        while(currentState == State.Attack)
        {
            aiMovement.AIMoveTowards(aiMovement.player);
            
            if (Vector2.Distance(transform.position, aiMovement.player.position) 
                >= aiMovement.chaseDistance)
            {
                currentState = State.BerryPicking;
            }
            
            yield return null;
        }
        Debug.Log("Attack: Exit");
        NextState();
    }
    
    private IEnumerator DefenceState()
    {
        Debug.Log("Defence: Enter");
        while(currentState == State.Defence)
        {
            Debug.Log("Currently Defending");
            yield return null;
        }
        Debug.Log("Defence: Exit");
        NextState();
    }
    
    private IEnumerator RunAwayState()
    {
        Debug.Log("RunAway: Enter");
        while(currentState == State.RunAway)
        {
            Debug.Log("Currently Running away");
            yield return null;
        }
        Debug.Log("RunAway: Exit");
        NextState();
    }
    
    
    
    private IEnumerator BerryPickingState()
    {
        Debug.Log("BerryPicking: Enter");
        
        aiMovement.LowestDistance();
        
        while(currentState == State.BerryPicking)
        {
            //update
            aiMovement.WaypointUpdate();
            aiMovement.AIMoveTowards(aiMovement.waypoints[aiMovement.waypointIndex]);
            
            if (Vector2.Distance(transform.position, aiMovement.player.position) 
                                    < aiMovement.chaseDistance)
            {
                currentState = State.Attack;
            }

            yield return null;
        }
        Debug.Log("BerryPicking: Exit");
        NextState();
    }
    
    
}
