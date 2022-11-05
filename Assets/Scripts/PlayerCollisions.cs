using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public PlayerData Data;
    HealthBar Health;
    SFXManager SFX;
    ReciveCoins ReciveCoins;
    public int healAmount, damageAmount;
    SnowBallManager SBM;

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

    void OnTriggerEnter(Collider col)
    {
        //AGARRAR MONEDA
        
        if (col.gameObject.tag == "Coin")
        {
            SFX.PlayCoinSound();
            ReciveCoins.reciveCoins(1);
            Destroy(col.gameObject.transform.parent.gameObject);
        }

        //AGARRAR CORAZON
        
        if (col.gameObject.tag == "Heal")
        {
            SFX.PlayHealSound();
            Data.playerHealth += healAmount; //Suma vida
            Destroy(col.gameObject.transform.parent.gameObject);            

            if (Data.playerHealth > Data.playerMaxHealth) //Si tiene mas vida que lo maximo
            {
                Data.playerHealth = Data.playerMaxHealth; //Lo iguala al maximo
            }
        }

        //AGARRAR CORAZON DE DAÑO

        if (col.gameObject.tag == "DamageObject")
        {
            Health.makeDamage(damageAmount);
            Destroy(col.gameObject.transform.parent.gameObject);
        }

        //AGARRAR BOLA DE NIEVE
        
        if (col.gameObject.tag == "SnowBall")
        {
            SBM.CollectSnowBall();
            Destroy(col.gameObject.transform.parent.gameObject);
        }


    }

    void OnLevelWasLoaded() //cuando carga la escena
    {
        string sceneName = SceneManager.GetActiveScene().name;
        
        if (sceneName == "FreezerScene")
        {
            SBM = GameObject.Find("[SNOWBALL-MANAGER]").GetComponent<SnowBallManager>();
        }
    }

}