using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Challenge : MonoBehaviour
{
    public delegate void completed();
    public event completed whenTheChallengeIsCompleted;
    //List<Enemigos> enemigosDisponibles
}
