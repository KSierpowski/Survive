using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float enemyHP = 100;



    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken");
        enemyHP -= damage;

        if (enemyHP <= 0)
        {
            Destroy(gameObject);
        }
    }




}
