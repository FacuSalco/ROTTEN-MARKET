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

    //coin spawn
    public CoinCreate coinSpawn;
    public GameObject coinPrefab;
    private Vector3 spawnPos;
    bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();

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
            Destroy(gameObject);

            if (spawn == true)
            {
                coinSpawn.SpawnCoin(coinPrefab, spawnPos);
                spawn = false;
            }

        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "espadapersonaje")
        {
            float damage = PlayerData.SwordData.weaponDamage;

            dealDamage(damage);
        }

        if (col.gameObject.tag == "handHitbox" || col.gameObject.tag == "rightHandHitbox")
        {
            float damage = PlayerData.PunchData.weaponDamage; //pasar a igualarlo al data de las upgrades

            dealDamage(damage);
        }
    }

    public void dealDamage(float damage)
    {
        currentHealth -= damage;
    }

}
