using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public bool IsOnMission = false;
    public bool IsOnKillingMission = false;

    public void StartMission()
    {
        IsOnMission = true;
    }

    public void FinishMission()
    {
        IsOnMission = false;
    }

    public void StartKillingMission()
    {
        IsOnKillingMission = true;
    }

    public void FinishKillingMission()
    {
        IsOnKillingMission = false;

    }
}
