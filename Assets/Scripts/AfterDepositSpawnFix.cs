using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDepositSpawnFix : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    [SerializeField] private Transform destino; // El objeto de destino al que se teleportará el jugador

    void start()
    {

    }
    void update()
    {
        if (player.transform.position.x > 250)
        {
            TeleportarJugador(player.transform);
            Debug.Log("El jugador ha sido teletransportado aaa " + destino.name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject == player) // Verifica si el objeto que entra en el trigger es el jugador
        {
            TeleportarJugador(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject == player) // Verifica si el objeto que sale del trigger es el jugador
        {
            TeleportarJugador(other.transform);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (other.gameObject == player) // Verifica si el objeto que está en el trigger es el jugador
        {
            TeleportarJugador(other.transform);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player) // Verifica si el objeto que entra en colisión es el jugador
        {
            TeleportarJugador(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player) // Verifica si el objeto que sale de la colisión es el jugador
        {
            TeleportarJugador(collision.transform);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (collision.gameObject == player) // Verifica si el objeto que está en colisión es el jugador
        {
            TeleportarJugador(collision.transform);
        }
    }

    private void TeleportarJugador(Transform jugador)
    {
        if (destino != null)
        {
            jugador.position = destino.position; // Teletransporta al jugador a la posición del destino
            Debug.Log("El jugador ha sido teletransportado a " + destino.name);
        }
        else
        {
            Debug.LogWarning("El objeto de destino no está asignado. Asigna un objeto en el Inspector.");
        }
    }
}