using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionStateChecker : MonoBehaviour
{

    public float CompletedMissionCount = 0;

    public void CompletedMission()
    {
        CompletedMissionCount++;
    }

}
