using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class EstadoPersecucion : MonoBehaviour {

    public Color ColorEstado = Color.red;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    private Animator controlDeAnimaciones;
    public float tiempoProximoAtaque;
    public float tiempoEntreAtaques;

	void Awake () {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        controlDeAnimaciones = GetComponent<Animator>();
        tiempoProximoAtaque = Time.time + tiempoEntreAtaques;
	}

    void OnEnable()
    {
        maquinaDeEstados.MeshRendererIndicador.material.color = ColorEstado;
    }
	
	void Update () {
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true))
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }
        if (controladorNavMesh.AlLadoDelPlayer() && Time.time > tiempoProximoAtaque)
        {
            tiempoProximoAtaque = Time.time + tiempoEntreAtaques;
            controlDeAnimaciones.SetTrigger("Attack");
        }
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();    
	}
}
