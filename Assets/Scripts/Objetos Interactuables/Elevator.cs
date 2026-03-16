using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Elevator : MonoBehaviour, IInteractable
{
    private bool _isOn = false;
    public string getInteractionText()
    {
        if (_isOn)
        {
            return "Usar el ascensor";
        }
        else
        {
            return "El ascensor no esta disponible";
        }
    }

    public void interact()
    {
        throw new System.NotImplementedException();
    }
}
