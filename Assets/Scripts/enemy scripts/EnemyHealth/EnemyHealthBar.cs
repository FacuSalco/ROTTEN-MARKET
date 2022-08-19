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
            
            coinSpawn.SpawnCoin(coinPrefab, spawnPos);
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
