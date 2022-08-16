using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarController : MonoBehaviour
{
    public float maxHealth;
    public float health;

    void Start()
    {
        health = maxHealth; 
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "espadapersonaje")
        { 
            health -= swordScript.swordDamage;
            Debug.Log("hit "+ health);
        }
    }
    
}
