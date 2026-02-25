using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armas : Objeto
{
    public string clase;

    public override void usar()
    {
        player.GetComponent<WeaponManager>().addWeapon(clase);
        Destroy(gameObject);
    }
}
