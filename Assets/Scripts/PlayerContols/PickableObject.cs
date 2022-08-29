using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : MonoBehaviour
{

    public bool isPickable = true;

    private void OnTriggerEnter(Collider other) //Detecta que el objeto entro en un trigger
    {
        if (other.tag == "PlayerInteractionZone") //Se fija que si lo que esta tocando es la zona de interaccion que le puse al player
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = this.gameObject; //busca en su padre el script PickUpObject y adentro de ese script busca la variable y le asigna nuestro player, le cambio el padre
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerInteractionZone")
        {
            other.GetComponentInParent<PickUpObject>().ObjectToPickUp = null;
        }
    }
}
