using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstMissionBehaviour : MonoBehaviour
{
    public GameObject BarrierBlocks;
    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();

        BarrierBlocks.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionChecker.CompletedMissionCount == 1)
        {
            BarrierBlocks.SetActive(false);
        }
    }
}
