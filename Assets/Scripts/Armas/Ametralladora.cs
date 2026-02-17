using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Weapon
{
    public int damage = 10;
    public float fireRate = 0.2f;

    private float nextFireTime;

    public GameObject balaPrefab;
    public Transform firePoint;
    public float balaVel = 10f;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;

        GameObject obj = Instantiate(balaPrefab, firePoint.position, firePoint.rotation);
        obj.GetComponent<BalaController>().speed = balaVel;
        obj.GetComponent<BalaController>().damage = damage;
    }
}
