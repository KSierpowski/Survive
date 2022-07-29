using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] float restoreAngle = 80f;
    [SerializeField] float intensityAmount = 3;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<Flashlight>().RestoreLightAngle(restoreAngle);
            FindObjectOfType<Flashlight>().RestoreLightIntensity(intensityAmount);
            Destroy(gameObject);
        }
    }
}
