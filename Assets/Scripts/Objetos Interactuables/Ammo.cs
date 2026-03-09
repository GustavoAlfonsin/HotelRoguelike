using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum tipo_municion
{
    Pistola,
    Escopeta,
    Ametralladora
}
public class Ammo : MonoBehaviour, IInteractable
{
    public tipo_municion type;
    public int amount; 

    public void asignarCantidad(int cant)
    {
        amount = cant;
    }
    public string getInteractionText()
    {
        return "Recoger munición de " + type.ToString();
    }

    public void interact()
    {
        WeaponManager playerInventory = FindObjectOfType<WeaponManager>();
        playerInventory.recogerMunicion(amount, type);
        Destroy(gameObject);
    }
}
