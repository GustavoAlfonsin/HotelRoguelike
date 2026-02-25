using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curación : Objeto
{
    private int cantidadACurar;
    public override void usar()
    {
        if (player != null)
        {
            player.GetComponent<playerControl>().curar(cantidadACurar);
            Destroy(gameObject);
        }
    }
}
