using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour, IWeapon
{
    public string weaponName;
    public Sprite icon;
    
    private bool activo = true;
    public virtual void Equip()
    {
        gameObject.SetActive(true);
    }

    public abstract void Shoot();

    public virtual void Unequip()
    {
        gameObject.SetActive(false);
    }

    public bool isActive()
    {
        return activo;
    }

    public abstract void recargar();
}
