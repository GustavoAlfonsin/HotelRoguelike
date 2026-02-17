using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Weapon
{
    public int damage = 10;
    public float fireRate = 0.2f;

    private float nextFireTime;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
    }
}
