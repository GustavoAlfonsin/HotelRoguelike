using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Weapon
{
    public int damage = 20;
    public float fireRate = 2f;

    private float nextFireTime;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
    }
}
