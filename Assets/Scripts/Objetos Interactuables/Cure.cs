using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cure : MonoBehaviour, IInteractable
{
    private int cantidadACurar = 20;
    public string getInteractionText()
    {
        return "Tomar curación";
    }

    public void interact()
    {
        playerControl player = FindObjectOfType<playerControl>();
        player.curar(cantidadACurar);
        Destroy(gameObject);
    }

    public void asignarValorCuración(int cant)
    {
        cantidadACurar = cant;
    }
}
