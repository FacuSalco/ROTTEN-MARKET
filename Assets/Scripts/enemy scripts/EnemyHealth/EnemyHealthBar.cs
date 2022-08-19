﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currentHealth;
    public float maximumHealth;

    //coin spawn
    public CoinCreate coinSpawn;
    public GameObject coinPrefab;
    private Vector3 spawnPos;
    bool spawn = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        coinSpawn = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<CoinCreate>();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maximumHealth;

        spawnPos = transform.position;

        if(currentHealth <= 0)
        {

            spawn = true;

            if(spawn == true)
            {
                coinSpawn.SpawnCoin(coinPrefab, spawnPos);
                spawn = false;
            }

            Destroy(gameObject);

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "espadapersonaje")
        {
            currentHealth -= swordScript.swordDamage;
            currentHealth -= swordScript.swordDamage;
        }
    }

}
