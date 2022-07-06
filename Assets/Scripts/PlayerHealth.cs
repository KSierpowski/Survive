using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float playerHP = 100f;


    void Start()
    {
        
    }

    public void TakeDamage(float damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            Debug.Log("You are dead");
        }
    }

}
