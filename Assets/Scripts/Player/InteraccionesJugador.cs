using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteraccionesJugador : MonoBehaviour
{
    public float interactionDistance = 1.5f;
    public Vector3 boxSize = new Vector3(1.2f,1f,1.2f);
    public LayerMask interactLayer;

    IInteractable currentInteractable;

    private PlayerInput _playerInput;

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        detectInteractable();
        if (_playerInput.actions["Interactuar"].WasPressedThisFrame() && currentInteractable != null)
        {
            currentInteractable.interact();
        }
    }

    private void detectInteractable()
    {
        Vector3 center = transform.position + transform.forward * interactionDistance;
        Collider[] hits = Physics.OverlapBox(center, boxSize / 2, transform.rotation, interactLayer);

        float closesDistance = Mathf.Infinity;
        currentInteractable = null;
        foreach (Collider hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();
            if (interactable != null)
            {
                float distance = Vector3.Distance(transform.position, hit.transform.position);
                if (distance < closesDistance)
                {
                    closesDistance = distance;
                    currentInteractable = interactable;
                }
            }
        }

        if (currentInteractable != null)
        {
            Debug.Log(currentInteractable.getInteractionText());
            //mostrar en la UI
            //UIInteraction.Instance.ShowText(currentInteractable.GetInteractionText());
        }
        else
        {
            // ocultar el texto en la UI
            //UIInteraction.Instance.HideText();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Vector3 center = transform.position + transform.forward * interactionDistance;

        Gizmos.matrix = Matrix4x4.TRS(center, transform.rotation, boxSize);
        Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
    }
}
