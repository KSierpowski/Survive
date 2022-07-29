using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 10;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float timeBetweenShoots = 0.5f;
    [SerializeField] TextMeshProUGUI ammoText;


    bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
   
    void Update()
    {
        DisplayAmmo();

        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.getCurrentAmmo(ammoType);
        ammoText.text =  ammoType +" "+ currentAmmo.ToString();
         
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.getCurrentAmmo(ammoType) > 0)    //to sa te ammoType, ktore wyzej mamy w serialized field
        {
            ProcessRaycast();
            PlayMuzzleFlash();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;

    }

    private void PlayMuzzleFlash()
    {
       muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else { return; }
    }
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact =  Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);     
    }
}
