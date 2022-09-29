using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Balanza : MonoBehaviour
    //NO ANDA, CUANDO TENGO UN OBJETO EN LA MANO Y LO SUELTO ES COMO SI EL PESO
    //DEL OBJETO SE DUPLICA. NO SE LE SACA EL PESO DE QUE LO SOLTO Y SE AGREGA
    //EL PESO DEL OBJETO. EJ: ENTRO CON OBJETO EN LA MANO Y PESA 201, SUELTO EL
    //OBJETO Y PESA 202.
{
    public float pesoOk, pesoActual, pesoApple;
    public GameObject objetoEnMano;
    bool playerOn;
    GameObject player;

    List<Rigidbody> currentRigidbodies = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pesoOk == pesoActual)
        {
            Debug.Log("Llego al peso requerido, " + pesoOk + "kg");
        }

        if (pesoActual < 0)
        {
            pesoActual = 0;
        }

        if (player.gameObject.GetComponentInChildren<PickableObject>()) //Si tiene algo en la mano
        {
            pesoApple = 200 + player.gameObject.GetComponentInChildren<PickableObject>().GetComponent<Rigidbody>().mass;
        }
        else //Si no tiene algo en la mano
        {
            pesoApple = 200;
        }

        ActualizarPeso();
    }

    void OnCollisionEnter(Collision col)
    {
        //if (col.gameObject == objetoEnMano)
        //{
        //    Debug.Log("El objeto es el mismo que tenia en la mano");
        //    return;
        //}

        //Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        //float colMasa = rb.mass;
        //pesoActual += colMasa;

        //LISTA


        currentRigidbodies.Add(col.rigidbody);
 

    }

    void OnCollisionExit(Collision col)
    {
        //Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        //float colMasa = rb.mass;
        //pesoActual -= colMasa;

        //LISTA  

        currentRigidbodies.Remove(col.rigidbody);
     
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            pesoActual += pesoApple;
            playerOn = true;


            //if (col.gameObject.GetComponentInChildren<PickableObject>()) //Se fija si tiene un hijo con el script PickableObject, osea si tiene algo en la mano
            //{
            //    objetoEnMano = col.gameObject.GetComponentInChildren<PickableObject>().gameObject; //Guarda el objeto que tiene en la mano
            //    Rigidbody rb = col.gameObject.GetComponentInChildren<PickableObject>().GetComponent<Rigidbody>(); //Agarra el rigidbody
            //    float colMasa = rb.mass; //Agarra la masa del rigidbody
            //    pesoActual += colMasa;
            //}

        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            pesoActual -= pesoApple;
            playerOn = false;

            //if (col.gameObject.GetComponentInChildren<PickableObject>())
            //{
            //    Rigidbody rb = col.gameObject.GetComponentInChildren<PickableObject>().GetComponent<Rigidbody>();
            //    float colMasa = rb.mass;
            //    pesoActual -= colMasa;
            //}
            //objetoEnMano = null;

        }
    }

    void ActualizarPeso()
    {
        if (playerOn)
        {
            pesoActual = pesoApple;
        }

        else
        {
            pesoActual = 0;
        }
        
        foreach (Rigidbody rigidbody in currentRigidbodies)
        {
            pesoActual += rigidbody.mass;
        }

    }
}
