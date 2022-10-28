using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionKillingNPC : MonoBehaviour
{
    public int EnemyMustKillAmount;
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
        if(NpcManager.DialogueManager.hasAcceptedMission && !NpcManager.DialogueManager.hasDoneMission)
        {
            MissionHand.StartKillingMission();
        }

        if (MissionHand.IsOnKillingMission)
        {
            if(EnemyKillCount == EnemyMustKillAmount)
            {
                if (CompleteMissionOnce)
                {
                    NpcManager.CompleteMission();
                    MissionHand.FinishKillingMission();

                    CompleteMissionOnce = false;
                }
            }

            if (NpcManager.hasFailedMission)
            {
                RestartMission();
            }
        }
    }

    public void EnemyKilled()
    {
        EnemyKillCount++;
    }

    private void RestartMission()
    {
        EnemyKillCount = 0;
        MissionHand.FinishKillingMission();
    }
}
