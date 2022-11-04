using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionLookForChildren : MonoBehaviour
{
    [Header("Spawns")]
    public GameObject[] ChildrenSpawnPos;
    public GameObject[] Children;
    public GameObject PlayerSpawn;
    private GameObject Player;

    [Header("Prefabs")]
    public GameObject ChildrenPrefab;
    public int FoundedChildren = 0;

    public bool SpawnChildrenOnce = true;
    private bool DestroyChildrenOnce = true;
    private bool ExecuteOnce = true;
    private bool hasFinishedQuest = false;

    private NpcDialgueManager NpcManager;
    private MissionStateChecker MissionState;
    private Fade Fader;

    // Start is called before the first frame update
    void Start()
    {
        //<>
        NpcManager = GetComponent<NpcDialgueManager>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Fader = GameObject.Find("Panel").GetComponent<Fade>();


    }

    // Update is called once per frame
    void Update()
    {
        if (FoundedChildren == 3 && !hasFinishedQuest)
        {
            NpcManager.CompleteMission();
            hasFinishedQuest = true;
        }


        if (NpcManager.DialogueManager.hasAcceptedMission && !NpcManager.DialogueManager.hasDoneMission)
        {
            //empieza mission
            if (SpawnChildrenOnce)
            {
                InstantiateChildren();
				Debug.Log("SPAWNED");
                SpawnChildrenOnce = false;
            }

            if (FoundedChildren == ChildrenSpawnPos.Length)
            {
                NpcManager.DialogueManager.hasDoneMission = true;
            }

        }

        if (NpcManager.DialogueManager.hasDoneMission)
        {
            if (ExecuteOnce)
            {
                StartCoroutine(FinishedQuest());
                ExecuteOnce = false;
            }

        }

        if (NpcManager.hasFailedMission)
        {

            if (DestroyChildrenOnce)
            {
                DestroyActiveChildren();
                DestroyChildrenOnce = false;
                RestartQuest();
            }
        }

    }

    IEnumerator FinishedQuest()
    {
        Fader.FadeOut();
        yield return new WaitForSeconds(2f);

        PlayerMove();
        Fader.FadeIn();
    }

    private void PlayerMove()
    {
        Player.transform.position = PlayerSpawn.transform.position;

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
        ExecuteOnce = true;
        FoundedChildren = 0;
    }

}
