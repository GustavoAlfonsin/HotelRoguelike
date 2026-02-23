using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : Weapon
{
    public int damage = 5;
    public float fireRate = 1.2f;
    private Animator _animator;
    private BoxCollider _filo;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _filo = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        _filo.isTrigger = true;
    }

    private float nextFireTime;
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
        _animator.SetTrigger("Attack");
        _filo.isTrigger = false;
        StartCoroutine(finAtaque());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemigo>().recibirDaño(damage);
        }
    }
    public override void recargar()
    {
    }

    IEnumerator finAtaque()
    {
        yield return new WaitForSeconds(1f);
        _filo.isTrigger = true;
    }
}
