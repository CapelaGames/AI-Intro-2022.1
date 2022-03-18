using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    [SerializeField] GameObject _combatCanvas;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AIMovement aiMove = collision.gameObject.GetComponent<AIMovement>();

        if(aiMove == null)
        {
            return;
        }
        Debug.Log("WE HAVE HIT AN AI");

        _combatCanvas.SetActive(true);
        Time.timeScale = 0;

        //_combatCanvas.SetActive(false); //once we finish combat
        //Time.timeScale = 1;
    }
}
