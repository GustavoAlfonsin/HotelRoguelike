using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Route
{
    List<Transform> positions = new List<Transform>();

    public Transform receiveRandomPosition()
    {
        int i = UnityEngine.Random.Range(0, positions.Count);
        return positions[i];
    }
}

public class Floor : MonoBehaviour
{
    List<Route> patrolRoutes = new List<Route>();
    List<GameObject> containers = new List<GameObject>();
    List<GameObject> switches = new List<GameObject>();

    public Route determineRoute()
    {
        int i = UnityEngine.Random.Range(0, patrolRoutes.Count);
        return patrolRoutes[i];
    }

    public Transform determinePosition()
    {
        int i = UnityEngine.Random.Range(0, patrolRoutes.Count);
        return patrolRoutes[i].receiveRandomPosition();
    }

    public GameObject grabContainer()
    {
        //Esto lo tiene que hacer si el contenedor esta vacio si no vuelve a buscar otro
        int i = UnityEngine.Random.Range(0, containers.Count);
        return containers[i];
    }

    public GameObject activateSwitches()
    {
        // Elegir el interruptor dependiendo de la dificultad
        return null;
    }
}
