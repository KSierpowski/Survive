using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] Canvas bloodCanvas;
    [SerializeField] float bloodTime = 0.2f;

    

    public void Start()
    {
        bloodCanvas.enabled = false;
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowBlood());
    }

    IEnumerator ShowBlood()
    {
        bloodCanvas.enabled=true;
         yield return new WaitForSeconds(bloodTime);
        bloodCanvas.enabled = false;
    }

}
