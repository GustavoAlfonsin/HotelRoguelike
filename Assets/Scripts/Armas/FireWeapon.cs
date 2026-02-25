using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : Weapon
{
    public int damage = 5;
    public float fireRate = 1f;
    public int municiónMaxima = 8;
    public int municionActual = 8;
    public int municiónExtra = 10;

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
        municionActual--;
        Debug.Log("Disparo de pistola");
    }

    public void recargar()
    {
        int balasFaltantes = municiónMaxima - municionActual;
        Debug.Log($"munición acttual: {municionActual} n/ balas faltantes: {balasFaltantes} n/ municion maxima: {municiónMaxima}");
        if (balasFaltantes <= municiónExtra)
        {
            municiónExtra = municiónExtra - balasFaltantes;
            municionActual = municiónMaxima;
        }
        else
        {
            municiónExtra = 0;
            municionActual = municionActual + (balasFaltantes - municiónExtra);
        }
        Debug.Log($"munición actual: {municionActual} n/ munición restante: {municiónExtra}");

    }

    public void agregarMunicion(int cant)
    {
        municiónExtra += cant;
    }
}
