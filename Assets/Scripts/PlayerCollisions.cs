using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //AGARRAR MONEDA
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            Debug.Log("Agarro moneda");
            GetComponent<PlayerStats>().Data.cantMonedas++; //Suma monedas
        }

        if (col.gameObject.tag == "Heal")
        {
            Destroy(col.gameObject);
            Debug.Log("Agarro corazon");
            GetComponent<PlayerStats>().Data.playerHealth += 15; //Suma vida

            if (GetComponent<PlayerStats>().Data.playerHealth > GetComponent<PlayerStats>().Data.playerMaxHealth) //Si tiene mas vida que lo maximo
            {
                GetComponent<PlayerStats>().Data.playerHealth = GetComponent<PlayerStats>().Data.playerMaxHealth; //Lo iguala al maximo
            }
        }
    }



}
