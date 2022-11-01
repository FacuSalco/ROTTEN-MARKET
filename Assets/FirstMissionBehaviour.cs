using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMissionBehaviour : MonoBehaviour
{
    public GameObject BarrierBlocks;
    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;
    private NpcDialgueManager NpcManager;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();
        NpcManager = GetComponent<NpcDialgueManager>();

        BarrierBlocks.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionChecker.CompletedMissionCount == 1)
        {
            BarrierBlocks.SetActive(false);
        }

        if (NpcManager.DialogueManager.hasAcceptedMission)
        {
            bool doOnce = true;
            if (doOnce)
            {
                MissionHand.IsOnKillingMission = true;
                doOnce = false;
            }
        }

        if (NpcManager.DialogueManager.hasDoneMission)
        {
            bool doOnce = true;
            if (doOnce)
            {
                MissionHand.IsOnKillingMission = false;
                doOnce = false;
            }
        }

        if (NpcManager.hasFinishedTalking)
        {
         //   Destroy(gameObject, 1f);
        }
    }
}
