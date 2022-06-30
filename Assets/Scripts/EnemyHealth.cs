using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hP = 100;



    public void TakeDamage(float damage)
    {

        hP -= damage;

        if (hP <= 0)
        {
            Destroy(gameObject);
        }
    }




}
