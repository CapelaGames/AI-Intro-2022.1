using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AIManager : BaseManager
{
    public enum State
    {
        HighHP,
        LowHP,
        Dead,
    }

    public State currentState;
    protected PlayerManager _playerManager;
    [SerializeField] protected Animator _anim;

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
            case State.HighHP:
                HighHPState();
                break;
            case State.LowHP:
                LowHPState();
                break;
            case State.Dead:
                DeadState();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected override void EndTurn()
    {
        StartCoroutine(WaitAndEndTurn());
    }

    private IEnumerator WaitAndEndTurn()
    {
        yield return new WaitForSecondsRealtime(2f);
        _playerManager.TakeTurn();
    }

    void LowHPState()
    {
        int randomAttack = Random.Range(0, 10);
        switch (randomAttack)
        {
            case int i when i >= 0 && i <= 1:
                SelfDestruct();
                break;
            case int i when i > 1 && i <=8:
                Rest();
                break;
            case int i when i > 8 && i <= 9:
                Splash();
                break;
        }

        if (_health > 60f)
        {
            currentState = State.HighHP;
        }
    }
    
    void HighHPState()
    {
        if (_health < 40f)
        {
            currentState = State.LowHP;
            LowHPState();
            return;
        }
        
        //random.range for ints
        //min number ==  inclusive
        //max number == exclusive
        
        //20% chance to use splash
        //70% chance to use iron tail
        //10% chance to use self destruct
        int randomAttack = Random.Range(0, 10);
        switch (randomAttack)
        {
            case int i when i >= 0 && i <= 1:
                Splash();
                break;
            case int i when i > 1 && i <=8:
                IronTail();
                break;
            case int i when i > 8 && i <= 9:
                SelfDestruct();
                break;
        }
    }
    
    void DeadState()
    {
        Debug.Log("AI IS DEAD YOU WIN");
    }
    
    public void Splash()
    {
        Debug.Log("Ai casts Splash");
        _playerManager.DealDamage(40.3f);
        _anim.SetTrigger("Splash");
        EndTurn();
    }

    public void IronTail()
    {
        Debug.Log("Ai casts Iron Tail");
        _playerManager.DealDamage(10f);
        EndTurn();
    }

    public void Rest()
    {
        Debug.Log("Ai Rests");
        Heal(30f);
        EndTurn();
    }

    public void SelfDestruct()
    {
        Debug.Log("Ai casts Self Destruct");
        DealDamage(_maxHealth);
        _playerManager.DealDamage(80f);
        EndTurn();
    }
}
