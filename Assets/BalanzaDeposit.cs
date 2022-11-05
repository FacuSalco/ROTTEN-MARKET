using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;
using System.Data.Common;

public class BalanzaDeposit : MonoBehaviour
{
    public int pesoAdecuado;
    public bool terminoPuzzle;
    public float pesoActual, pesoApple;
    bool playerOn, yaGano;
    GameObject player;
    public TextMeshPro txtPeso, txtPesoAdecuado;
    SFXManager SFX;
    ReciveCoins ReciveCoins;
    public GameObject persiana;

    List<Rigidbody> currentRigidbodies = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        txtPesoAdecuado.text = "EXACTAMENTE " + pesoAdecuado.ToString() + "G PESARAS Y LA PERSIANA ABRIRAS";
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
        ReciveCoins = GameObject.Find("[RECIVE-COINS]").GetComponent<ReciveCoins>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Si el peso adecuado es igual al peso actual durante 1 segundo entonces gana  

        if (pesoAdecuado == pesoActual)
        {
            Invoke("CheckOneSecond", 1);
            //Para hacer que no tenga que estar 1 segundo descomnetar la linea de abajo y comentar la de arriba
            //terminoPuzzle = true;
        }

        if (terminoPuzzle && !yaGano) //---------------GANO---------------//
        {
            yaGano = true;
            txtPeso.color = Color.green;
            txtPeso.text = pesoAdecuado.ToString() + "g";
            terminoPuzzle = true;
            SFX.PlayQuestCompleteSound();
            persiana.GetComponent<Animator>().Play("AbrirPersiana2");
            Debug.Log("GANO");
        }

        if (pesoActual < 0)
        {
            pesoActual = 0;
        }

        if (player.gameObject.GetComponentInChildren<PickableObject>()) //Si tiene algo en la mano
        {
            pesoApple = 200 + player.gameObject.GetComponentInChildren<PickableObject>().GetComponent<Rigidbody>().mass * 100;
        }
        else //Si no tiene algo en la mano
        {
            pesoApple = 200;
        }

        if (!terminoPuzzle)
        {
            ActualizarPeso();
            txtPeso.text = int.Parse(pesoActual.ToString()) + "g";
        }


    }

    void OnCollisionEnter(Collision col)
    {
        currentRigidbodies.Add(col.rigidbody);
    }

    void OnCollisionExit(Collision col)
    {
        currentRigidbodies.Remove(col.rigidbody);
    }

    void OnTriggerEnter(Collider col)
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
            pesoActual += rigidbody.mass * 100;
        }

    }

    void CheckOneSecond()
    {
        if (pesoAdecuado == pesoActual && !terminoPuzzle)
        {
            terminoPuzzle = true;
        }
    }

}
