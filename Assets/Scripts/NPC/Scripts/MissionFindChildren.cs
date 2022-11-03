using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFindChildren : MonoBehaviour
{

    [Header("Spawns")]
    public GameObject[] ChildrenSpawnPos;
    private GameObject[] Children;
    public GameObject PlayerSpawn;
    private GameObject Player;

    [Header("Prefabs")]
    public GameObject ChildrenPrefab;
    private int FoundedChildren = 0;

    private bool SpawnChildrenOnce = true;
    private bool DestroyChildrenOnce = true;

    private NpcDialgueManager NpcManager;
    private MissionStateChecker MissionState;
    private Fade Fader;

    // Start is called before the first frame update
    void Start()
    {
        //<>
        NpcManager = GetComponent<NpcDialgueManager>();
        Player = GameObject.FindGameObjectWithTag("Player");

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

            if(FoundedChildren == ChildrenSpawnPos.Length)
            {
                NpcManager.DialogueManager.hasDoneMission = true;
            }

        }

        if (NpcManager.DialogueManager.hasDoneMission)
        {
            

            Player.transform.position = PlayerSpawn.transform.position;


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
            Children[i] = Instantiate(ChildrenPrefab, ChildrenSpawnPos[i].transform.position, Quaternion.identity);
        }
    }

    private void DestroyActiveChildren()
    {
        for (int i = 0; i < Children.Length; i++)
        {
            Destroy(Children[i]);
        }
    }

    public void HasFoundChild()
    {
        FoundedChildren++;
    }

    private void RestartQuest()
    {
        SpawnChildrenOnce = true;
        DestroyChildrenOnce = true;
        FoundedChildren = 0;

        DestroyActiveChildren();

    }

}
