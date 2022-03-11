using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseManager : MonoBehaviour
{
    //serializeField means we can modify this in unity even if its private
    [SerializeField] protected float _health = 100f;
    [SerializeField] protected float _maxHealth = 100f;
    [SerializeField] protected Text _healthText;

    //virtual allows the function to be "overridden" by child classes
    //override replaces the parent class's function (must be marked as virtual)
    protected virtual void Start()
    {
        UpdateHealthText();
    }

    public abstract void TakeTurn();
    protected abstract void EndTurn();

    private void UpdateHealthText()
    {
        if (_healthText != null)
        {
            _healthText.text = _health.ToString("n0");
        }
    }
    
    public void Heal(float heal)
    {
        _health = Mathf.Min(_health + heal, _maxHealth);
        UpdateHealthText();
    }
    
    public void DealDamage(float damage)
    {
        _health = Mathf.Max(_health - damage, 0);

        if (_health <= 0)
        {
            _health = 0;
            Debug.Log("I Died");
        }

        UpdateHealthText();
    }
}
