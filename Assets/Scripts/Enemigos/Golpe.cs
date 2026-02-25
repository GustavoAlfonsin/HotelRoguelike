using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golpe : MonoBehaviour
{
    public int damage = 5;
   
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Toco algo");
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<playerControl>().recibirDaño(damage);
        }
    }
}
