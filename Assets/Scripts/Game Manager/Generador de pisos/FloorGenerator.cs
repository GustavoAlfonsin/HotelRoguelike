using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [Header("Lista de pisos")]
    public List<Floor> firstPhaseApartment = new List<Floor>();
    public List<Floor> secondPhaseApartment = new List<Floor>();
    public List<Floor> thirdPhaseApartmente = new List<Floor>();
    public List<Floor> bossesFloors = new List<Floor>();
    public Floor sixtiethFloor;

    [Header("Enemigos y jefes")]
    public List<Enemigo> enemies;
    //public List<Jefes> bosses;

    [Header("Datos extras")]
    public int currentPhase;

    public void nextFloor(int phase)
    {

    }

    public void backToTheSixtiethFloor()
    {

    }

    private void putThePlayer()
    {

    }

    public void goToTheBossFloor(int phase)
    {

    }
}
