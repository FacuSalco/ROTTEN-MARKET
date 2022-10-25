using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using TMPro;

public class Balanza : MonoBehaviour
{
    public int pesoAdecuado, coinReward;
    public bool terminoPuzzle;
    public float pesoActual, pesoApple;
    bool playerOn, yaGano;
    GameObject player;
    public TextMeshPro txtPeso, txtPesoAdecuado;
    SFXManager SFX;
    ReciveCoins ReciveCoins;

    List<Rigidbody> currentRigidbodies = new List<Rigidbody>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        txtPesoAdecuado.text =  "Exactamente " + pesoAdecuado.ToString() + "g pesaras y una sorpresa te llevaras";
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

            player.GetComponent<PlayerController1>().enabled = false;
            Invoke("EnablePlayer", 5f);
            
            Invoke("CoinReward", 4);
            Invoke("CoinReward", 4.2f);
            Invoke("CoinReward", 4.4f);
            Invoke("CoinReward", 4.6f);
            Invoke("CoinReward", 4.8f);
            Invoke("CoinReward", 5);
        }

        if (pesoActual < 0)
        {
            pesoActual = 0;
        }

        if (player.gameObject.GetComponentInChildren<PickableObject>()) //Si tiene algo en la mano
        {
            pesoApple = 200 + player.gameObject.GetComponentInChildren<PickableObject>().GetComponent<Rigidbody>().mass*100;
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
            pesoActual += rigidbody.mass *100;
        }

    }

    void CheckOneSecond()
    {
        if (pesoAdecuado == pesoActual && !terminoPuzzle)
        {
            terminoPuzzle = true;
        }
    }

    void EnablePlayer() //Para volver a permiterle al player moverse
    {
        player.GetComponent<PlayerController1>().enabled = true;
    }

    void CoinReward()
    {
        SFX.PlayCoinSound();
        ReciveCoins.reciveCoins(coinReward);
    }

}
