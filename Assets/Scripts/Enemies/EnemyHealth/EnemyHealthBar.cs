using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currentHealth;
    public float maximumHealth;

    private PlayerStats PlayerData;
    private bool doDamageOnce;

    //coin spawn
    public CoinCreate coinSpawn;
    public GameObject coinPrefab;
    private Vector3 spawnPos;
    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        coinSpawn = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<CoinCreate>();

        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maximumHealth;

        spawnPos = transform.position;

        if(currentHealth <= 0)
        {
            Destroy(gameObject);

            if (spawn == true)
            {
                coinSpawn.SpawnCoin(coinPrefab, spawnPos);
                spawn = false;
            }

        }
    }

    public void dealDamage(float damage)
    {
        currentHealth -= damage;
    }

}
