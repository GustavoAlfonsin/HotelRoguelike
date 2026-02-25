using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tipo_municion
{
    Pistola,
    Escopeta,
    Ametralladora
}

public class Munición : Objeto
{
    public int cantidad;
    public tipo_municion tipo;

    public void asignarCantidadYTipo(int cant, tipo_municion gun)
    {
        cantidad = cant;
        tipo = gun;
    }

    public override void usar()
    {
        if (player != null)
        {
            player.GetComponent<WeaponManager>().recogerMunicion(cantidad, tipo);
            Destroy(gameObject);
        }
    }
}
