using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : Weapon
{
    public int damage = 5;
    public float fireRate = 1.2f;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
    }

    private float nextFireTime;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
        _animator.SetTrigger("Attack");
    }
}
