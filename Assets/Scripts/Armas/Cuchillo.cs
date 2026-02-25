using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cuchillo : Weapon
{
    public int damage = 5;
    public float fireRate = 1.2f;
    private Animator _animator;
    private BoxCollider _filo;

    private float nextFireTime;

    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _filo = GetComponent<BoxCollider>();
        activo = true;
    }

    private void Start()
    {
        _filo.isTrigger = true;
    }
    public override void Shoot()
    {
        if (Time.time < nextFireTime) return;
        nextFireTime = Time.time + fireRate;
        _filo.isTrigger = false;
        _animator.SetTrigger("Attack");
        StartCoroutine(finAtaque());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Toco algo");
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            collision.gameObject.GetComponent<Enemigo>().recibirDaño(damage);
        }
    }
    IEnumerator finAtaque()
    {
        yield return new WaitForSeconds(1f);
        _filo.isTrigger = true;
    }
}
