using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    public float currentHealth;
    public float maximumHealth;



    //coin spawn
    CoinCreate coinSpawn;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
        coinSpawn = GetComponent<CoinCreate>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maximumHealth;

        if(currentHealth <= 0)
        {
            
            coinSpawn.SpawnCoin();
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
