using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateFKeyImage : MonoBehaviour
{
    //Poner para que se fije si el player esta agarrado algo (Lo podes ver en el de la shoplist)

    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    void Update()
    {
        //Fijarme en el padre el script PickableObject si isPicked es verdadero
        if (gameObject.GetComponentInParent<PickableObject>().isPicked)
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }

    }

    void OnTriggerStay(Collider col) //EL PLAYER ESTA CERCA
    {
        if (col.gameObject.tag == "Player") //Agregar si no esta agarrado
        {
            gameObject.GetComponent<Canvas>().enabled = true;
        }
    }

    void OnTriggerExit(Collider col) //EL PLAYER ESTA LEJOS
    {
        if (col.gameObject.tag == "Player") //Poner lo de que si esta agarrando aca
        {
            gameObject.GetComponent<Canvas>().enabled = false;
        }
    }

}
