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

    [Header("Mission")]

    public bool hasAcceptedMission;
    public bool hasDoneMission;
    public bool hasTalked;

    [Header("Mission Time")]

    public float missionTime;
    public bool missionHasTime;

    [Header("Rewards")]

    public int coinReward;
}
