using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : Weapon
{
    public int damage = 5;
    public float fireRate = 1f;

    private float nextFireTime;

    public GameObject balaPrefab;
    public Transform firePoint;
    public float balaVel = 10f;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
        GameObject obj = Instantiate(balaPrefab, firePoint.position,firePoint.rotation);
        obj.GetComponent<BalaController>().speed = balaVel;
        obj.GetComponent<BalaController>().damage = damage;
        Debug.Log("Disparo de pistola");
    }
}
