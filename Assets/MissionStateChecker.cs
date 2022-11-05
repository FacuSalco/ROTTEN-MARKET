using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStateChecker : MonoBehaviour
{

    public float CompletedMissionCount = 0;

    public bool FirstQuestDone = false;
    public bool SecondQuestDone = false;
    public bool ThirdQuestDone = false;

    public void CompletedMission()
    {
        CompletedMissionCount++;
    }

}
