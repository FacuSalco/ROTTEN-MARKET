using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionKillingNPC : MonoBehaviour
{
    public int EnemyMustKillAmount;
    public int EnemyKillCount;
    private bool CompleteMissionOnce = true;
    private bool StartKillingMissionOnce = true;

    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;
    private NpcDialgueManager NpcManager;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();
        NpcManager = GetComponent<NpcDialgueManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if(NpcManager.DialogueManager.hasAcceptedMission && !NpcManager.DialogueManager.hasDoneMission)
        {
            if (StartKillingMissionOnce)
            {
                MissionHand.StartKillingMission();
                StartKillingMissionOnce = false;
            }

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
                    MissionChecker.SecondQuestDone = true;
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
        StartKillingMissionOnce = true;
    }
}
