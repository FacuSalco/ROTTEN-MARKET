using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordScritp : MonoBehaviour
{
    private bool DoOnEnter = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
