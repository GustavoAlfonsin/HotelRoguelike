using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class ControladorNavMesh : MonoBehaviour {

    [HideInInspector]
    public Transform perseguirObjectivo;

    private NavMeshAgent navMeshAgent;

	void Awake () {
        navMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino) {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;
    }

    public void ActualizarPuntoDestinoNavMeshAgent()
    {
        ActualizarPuntoDestinoNavMeshAgent(perseguirObjectivo.position);
    }

    public void DetenerNavMeshAgent()
    {
        navMeshAgent.isStopped = true;
    }

    public bool HemosLlegado()
    {
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }

    public bool AlLadoDelPlayer()
    {
        return navMeshAgent.remainingDistance <= 2f;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawRay(transform.position, transform.forward *2f);
    //}
}
