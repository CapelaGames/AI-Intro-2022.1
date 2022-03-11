using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIManager : BaseManager
{
    public enum State
    {
        FullHP,
        LowHP,
        Dead,
    }
    
    public State currentState;
    protected PlayerManager _playerManager;
    
    protected override void Start()
    {
        base.Start();
        
        _playerManager = GetComponent<PlayerManager>();
        if (_playerManager == null)
        {
            Debug.LogError("PlayerManager not found");
        }
    }
    
    public override void TakeTurn()
    {
        if (_health <= 0f)
        {
            currentState = State.Dead;
        }

        switch (currentState)
        {
            case State.FullHP:
                FullHPState();
                if (_health > 0)
                {
                    StartCoroutine(EndTurn());
                }

                break;
            case State.LowHP:
                LowHPState();
                if (_health > 0)
                {
                    StartCoroutine(EndTurn());
                }

                break;
            case State.Dead:
                DeadState();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        
    }

    IEnumerator EndTurn()
    {
        yield return new WaitForSeconds(2f);
        _playerManager.TakeTurn();
    }

    void LowHPState()
    {
        int randomAttack = Random.Range(0, 10);

        switch (randomAttack)
        {
            case int i when i > 0 && i <= 1:
                SelfDestruct();
                break;
            case int i when i > 1 && i <= 8:
                EatBerries();
                break;
            case int i when i > 8 && i <= 9:
                FlameWheel();
                break;
        }
        
        if (_health > 60f)
        {
            currentState = State.FullHP;
        }
    }

    void DeadState()
    {
        Debug.Log("AI IS DEAD YOU WIN");
    }

    void FullHPState()
    {
        if (_health < 40f)
        {
            currentState = State.LowHP;
            LowHPState();
            return;
        }
        
        int randomAttack = Random.Range(0, 10);
        switch (randomAttack)
        {
            case int i when i > 0 && i <= 2:
                FlameWheel();
                break;
            case int i when i > 2 && i <= 8:
                VineWhip();
                break;
            case int i when i > 8 && i <= 9:
                SelfDestruct();
                break;
        }
    }
    
    
    public void EatBerries()
    {
        Debug.LogWarning("Ai Ate Berries");
        Heal(20f);

    }
    public void SelfDestruct()
    {
        Debug.LogWarning("Ai Self Destruct");
        DealDamage(_maxHealth);
        _playerManager.DealDamage(80f);
        currentState = State.Dead;
    }

    public void VineWhip()
    {
        Debug.LogWarning("Ai cast vine whip!");
        _playerManager.DealDamage(30f);
    }

    public void FlameWheel()
    {
        Debug.LogWarning("Ai cast Flame Wheel!");
        _playerManager.DealDamage(50f);
    }
    
}
