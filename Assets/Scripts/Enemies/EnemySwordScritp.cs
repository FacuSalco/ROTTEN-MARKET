using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScritp : MonoBehaviour
{
    private bool DoOnEnter = true;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");


    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (DoOnEnter)
            {
                int damage = 10;

                HealthBar PlayerHealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();

                PlayerHealthBar.makeDamage(damage);

                DoOnEnter = false;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            DoOnEnter = true;
        }
    }
}
