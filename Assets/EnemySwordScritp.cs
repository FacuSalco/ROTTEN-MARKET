using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScritp : MonoBehaviour
{
    private bool DoOnEnter = true;

    void OnTriggerEnter()
    {
        if (DoOnEnter)
        {
            int damage = 10;

            HealthBar PlayerHealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();

            PlayerHealthBar.makeDamage(damage);

            DoOnEnter = false;
        }

    }

    void OnTriggerExit()
    {
        DoOnEnter = true;
    }
}
