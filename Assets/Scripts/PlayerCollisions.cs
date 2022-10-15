using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerData Data;
    HealthBar Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<HealthBar>();
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
            Data.cantMonedas++; //Suma monedas
        }

        if (col.gameObject.tag == "Heal")
        {
            Destroy(col.gameObject);
            Debug.Log("Agarro corazon");
            Data.playerHealth += 15; //Suma vida

            if (Data.playerHealth > Data.playerMaxHealth) //Si tiene mas vida que lo maximo
            {
                Data.playerHealth = Data.playerMaxHealth; //Lo iguala al maximo
            }
        }

        if (col.gameObject.tag == "DamageObject")
        {
            Health.makeDamage(10);
            Destroy(col.gameObject);
        }
    }
}