using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Balanza : MonoBehaviour
{
    public float pesoOk, pesoActual, pesoApple;
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
        currentRigidbodies.Add(col.rigidbody);
    }

    void OnCollisionExit(Collision col)
    {
        currentRigidbodies.Remove(col.rigidbody);
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            pesoActual += pesoApple;
            playerOn = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            pesoActual -= pesoApple;
            playerOn = false;
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
