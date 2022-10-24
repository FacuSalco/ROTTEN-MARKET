using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerData Data;
    HealthBar Health;
    SFXManager SFX;
    ReciveCoins ReciveCoins;
    public int healAmount, damageAmount;

    // Start is called before the first frame update
    void Start()
    {
        Health = GetComponent<HealthBar>();
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
        ReciveCoins = GameObject.Find("[RECIVE-COINS]").GetComponent<ReciveCoins>();
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
            SFX.PlayCoinSound();
            Destroy(col.gameObject);
            Debug.Log("Agarro moneda");
            ReciveCoins.reciveCoins(1);
        }

        if (col.gameObject.tag == "Heal")
        {
            SFX.PlayHealSound();
            Destroy(col.gameObject);
            Debug.Log("Agarro corazon");
            Data.playerHealth += healAmount; //Suma vida

            if (Data.playerHealth > Data.playerMaxHealth) //Si tiene mas vida que lo maximo
            {
                Data.playerHealth = Data.playerMaxHealth; //Lo iguala al maximo
            }
        }

        if (col.gameObject.tag == "DamageObject")
        {
            Health.makeDamage(damageAmount);
            Destroy(col.gameObject);
        }
    }
}