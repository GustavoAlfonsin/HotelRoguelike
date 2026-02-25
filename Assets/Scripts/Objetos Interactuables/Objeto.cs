using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Objeto : MonoBehaviour
{
    private BoxCollider zonaInteracción;
    public Vector3 dimensiones;
    public bool sePuedeUsar;
    protected GameObject player;

    private void Awake()
    {
        zonaInteracción = GetComponent<BoxCollider>();
        zonaInteracción.size = dimensiones;
        sePuedeUsar = false;
    }

    public abstract void usar();

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sePuedeUsar = true;
            player = other.gameObject;
            other.GetComponent<playerControl>().objetoCerca = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            sePuedeUsar = false;
            other.GetComponent<playerControl>().objetoCerca = null;
            player = null;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = sePuedeUsar ? Color.yellow : Color.white;
        Gizmos.DrawCube(transform.position, dimensiones);
    }
}
