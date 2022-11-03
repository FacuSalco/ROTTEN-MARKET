using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLookForChildren : MonoBehaviour
{
    public GameObject[] ChildrenSpawnPos;
    public GameObject[] Children;

    public GameObject ChilderPrefab;

    private bool SpawnChildrenOnce = true;
    private bool DestroyChildrenOnce = true;

    private NpcDialgueManager NpcManager;
    private MissionStateChecker MissionState;

    // Start is called before the first frame update
    void Start()
    {
        //<>
        NpcManager = GetComponent<NpcDialgueManager>();

        
    }

    // Update is called once per frame
    void Update()
    {
        if (NpcManager.DialogueManager.hasAcceptedMission && !NpcManager.DialogueManager.hasDoneMission)
        {
            //empieza mission
            if (SpawnChildrenOnce)
            {
                InstantiateChildren();
                SpawnChildrenOnce = false;
            }
            

        }

        if (NpcManager.DialogueManager.hasDoneMission)
        {

        }

        if (NpcManager.hasFailedMission)
        {

            if (DestroyChildrenOnce)
            {
                DestroyActiveChildren();
                DestroyChildrenOnce = false;
            }
        }

    }

    private void InstantiateChildren()
    {
        for (int i = 0; i < ChildrenSpawnPos.Length; i++)
        {
           Children[i] = Instantiate(ChilderPrefab, ChildrenSpawnPos[i].transform.position, Quaternion.identity);
        }
    }

    private void DestroyActiveChildren()
    {
        for(int i = 0; i < Children.Length; i++)
        {
            Destroy(Children[i]);
        }
    }

    private void RestartQuest()
    {
        SpawnChildrenOnce = true;
        DestroyChildrenOnce = true;
    }

}
