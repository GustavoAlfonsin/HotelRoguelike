using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    private bool isOn = false;
    public Color colorEncendido, colorApagado;

    public delegate void touchSwitch(bool onOff, Vector3 position);
    public event touchSwitch whenTheSwitchIsTouched; 

    public void inicializarInterruptor()
    {
        isOn = false;
        gameObject.GetComponent<Material>().color = colorApagado;

    }
    public string getInteractionText()
    {
        return "Usar interruptor";
    }

    public void interact()
    {
        isOn = !isOn;
        if (isOn)
        {
            gameObject.GetComponent<Material>().color = colorEncendido;
        }
        else
        {
            gameObject.GetComponent<Material>().color = colorApagado;
        }

        if (whenTheSwitchIsTouched != null) 
        {
            whenTheSwitchIsTouched(isOn, transform.position);
        }
    }
}
