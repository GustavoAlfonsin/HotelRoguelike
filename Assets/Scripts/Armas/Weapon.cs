using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public string weaponName;
    public Sprite icon;
    
    protected bool activo = false;
    public virtual void Equip()
    {
        gameObject.SetActive(true);
    }

    public abstract void Shoot();

    public virtual void Unequip()
    {
        gameObject.SetActive(false);
    }

    public void activarArma()
    {
        activo = true;
    }
    public bool isActive()
    {
        return activo;
    }
}
