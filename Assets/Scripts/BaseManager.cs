using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseManager : MonoBehaviour
{
    //protected is basically private,
    //but inherited classes also have access to it
    [SerializeField] protected float _health = 100;
    [SerializeField] protected float _maxHealth = 100;
    [SerializeField] protected Text _healthText;

    //virtual allows the function to be "overridden" by child classes
    //override replaces parent class's function (must be marked virtual)
    protected virtual void Start()
    {
        UpdateHealthText();
    }
    
    //abstract classes cannot be used, only childern of abstract classes
    //abstract function (inside an abstract class) has to be implemented by child classes
    public abstract void TakeTurn();
    

    public void UpdateHealthText()
    {
        if (_healthText != null)
        {
            _healthText.text = _health.ToString("0");
        }
    }
    
    public void Heal(float heal)
    {
        _health = Mathf.Min(_health + heal, _maxHealth);
        UpdateHealthText();
    }
    
    public void DealDamage(float damage)
    {
        _health = Mathf.Max( _health - damage , 0);

        if (_health <= 0)
        {
            //_health = 0;
            Debug.Log("I Died");
        }

        UpdateHealthText();
    }
}
