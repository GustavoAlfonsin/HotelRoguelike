using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunPickup : MonoBehaviour, IInteractable
{
    public string gunName;
    public string getInteractionText()
    {
        return "recoger " + gunName;
    }

    public void interact()
    {
        WeaponManager playerInventory = FindObjectOfType<WeaponManager>();
        playerInventory.addWeapon(gunName);
        Destroy(gameObject);
    }
}
