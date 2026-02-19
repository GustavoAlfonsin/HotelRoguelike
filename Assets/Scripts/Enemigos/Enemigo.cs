using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemigo : MonoBehaviour
{
    private int vidaTotal = 100;
    private int vidaActual = 100;

   public void recibirDaño(int daño)
    {
        vidaActual -= daño;
        Debug.Log($"Vida actual:{vidaActual}");
        if (vidaActual <= 0)
        {
            morir();
        }
    }

    private void morir()
    {
        Destroy(gameObject);
        //Dejar objetos
    }
}
