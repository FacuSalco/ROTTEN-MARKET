using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "NpcData")]
public class npcScriptableObject : ScriptableObject
{
    [Header("Dialogues")]

    public string[] dialoguesBeforeMission;
    public string mission;
    public string[] dialoguesAfterMission;

    [Header("MissionState")]

    public bool hasAcceptedMission;
    public bool hasDoneMission;
    public bool hasTalked;

    [Header("Rewards")]

    public int coinReward;
}
