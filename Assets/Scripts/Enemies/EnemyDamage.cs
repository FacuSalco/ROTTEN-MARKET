using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    private bool DoOnEnter = true;
    public EnemyData DamageData;
    private HealthBar PlayerHealthBar;
    private int Damage;

    void Start()
    {
        PlayerHealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();

        Damage = DamageData.enemyData.WeaponDamage;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (DoOnEnter)
            {
                PlayerHealthBar.makeDamage(Damage);

                DoOnEnter = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            DoOnEnter = true;
        }
    }

}
