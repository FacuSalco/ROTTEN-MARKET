using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image healthBar;
    private float currentHealth;
    public float maximumHealth;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maximumHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = currentHealth / maximumHealth;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "espadapersonaje")
        {
            currentHealth -= swordScript.swordDamage;
        }
    }

}
