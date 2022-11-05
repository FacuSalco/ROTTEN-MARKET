using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    bool x2Coins;
    public GameObject deathCanvas;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

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
            Data.x2Coins = x2Coins;

            Data.resetNextGame = false;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetBtn()
    {
        Data.playerHealth = Data.playerMaxHealth;
        Time.timeScale = 1f;
        PauseBehaviour.gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        deathCanvas.SetActive(false);
    }

}
