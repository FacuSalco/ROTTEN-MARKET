using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowAccessScritp : MonoBehaviour
{
    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionChecker.FirstQuestDone && MissionChecker.SecondQuestDone)
        {
            this.gameObject.SetActive(false);
        }
    }
}
