using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAliveChecker : MonoBehaviour
{
    public MissionKillingNPC MissionNpc;
    private EnemyHealthBar EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = GetComponent<EnemyHealthBar>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth.currentHealth < 0)
        {
            MissionNpc.EnemyKilled();
        }
    }
}
