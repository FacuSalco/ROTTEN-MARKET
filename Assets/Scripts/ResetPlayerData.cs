using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerData : MonoBehaviour
{
    public PlayerData Data;
    int cantMonedas = 0;
    float playerHealth = 100;
    float playerMaxHealth = 100;
    float playerDamage = 40;
    float playerSpeed = 5;
    float playerJumpForce = 10;
    int[] timesUpgraded = new int[5];
    bool hasSword = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < timesUpgraded.Length; i++)
        {
            timesUpgraded[i] = 0;
        }

        if (Data.resetNextGame || Data.resetAlways)
        {
            if (Data.keepCoins == false)
            {
                Data.cantMonedas = cantMonedas;
            }            
            
            Data.playerHealth = playerHealth;
            Data.playerMaxHealth = playerMaxHealth;
            Data.playerDamage = playerDamage;
            Data.playerSpeed = playerSpeed;
            Data.playerJumpForce = playerJumpForce;
            Data.timesUpgraded = timesUpgraded;
            Data.hasSword = hasSword;
            
            Data.resetNextGame = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
