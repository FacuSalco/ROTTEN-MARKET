using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NpcData", menuName = "NpcData")]
public class npcScriptableObject : ScriptableObject
{
    public string[] dialoguesBeforeMission;
    public string mission;
    public string[] dialoguesAfterMission;
    public bool hasAcceptedMission;
    public bool hasDoneMission;
    public bool hasTalked;
    public int coinReward;
}
