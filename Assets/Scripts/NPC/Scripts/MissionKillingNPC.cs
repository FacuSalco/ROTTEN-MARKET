using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionKillingNPC : MonoBehaviour
{
    public int EnemyKillAmount;
    private int EnemyKillAmountDelta;
    public int EnemyKillCount;
    private bool CompleteMissionOnce = true;

    private MissionHandler MissionHand;
    private NpcDialgueManager NpcManager;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        NpcManager = GetComponent<NpcDialgueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MissionHand.IsOnKillingMission)
        {
            if(EnemyKillCount == EnemyKillAmount)
            {
                if (CompleteMissionOnce)
                {
                    NpcManager.CompleteMission();
                    CompleteMissionOnce = false;
                }
            }

            if (NpcManager.hasFailedMission)
            {
                EnemyKillCount = 0;
            }
        }
    }
}
