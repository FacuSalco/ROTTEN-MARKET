using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAliveChecker : MonoBehaviour
{
    public MissionKillingNPC MissionNpc;
    private EnemyHealthBar EnemyHealth;
    private MissionHandler MissionHand;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = GetComponent<EnemyHealthBar>();
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyHealth.currentHealth <= 0 && MissionHand.IsOnKillingMission)
        {
            bool doOnce = true;
            if (doOnce)
            {
                MissionNpc.EnemyKilled();
                Debug.Log("Enemigo eliminado");
                doOnce = false;
            }
        }
    }
}
