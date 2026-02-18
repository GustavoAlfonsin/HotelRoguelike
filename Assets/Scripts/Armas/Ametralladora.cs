using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ametralladora : Weapon
{
    public int damage = 10;
    public float fireRate = 0.2f;
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
    }

    public override void recargar()
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
}
