using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : Weapon
{
    public int damage = 5;
    public float fireRate = 0.5f;

    private float nextFireTime;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;

        Debug.Log("Disparo de pistola");
    }
}
