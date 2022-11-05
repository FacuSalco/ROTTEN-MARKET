using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkingNpc : MonoBehaviour
{
    public GameObject NpcCanvas;
    public GameObject DialogueCanvas;
    public GameObject MissionCanvas;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NextText;

    public string[] Dialogues;

    private int DialogueCounter = 0;
    private bool playerOnRange = false;
    private bool doDesactivateOnce = true;
    private bool HasTalked = false;
    private string pressE = "Presione ¨E¨ para continuar";

    private Animator NpcAnimator;
    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;

    // Start is called before the first frame update
    void Start()
    {
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();
        NpcAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(playerOnRange && !MissionHand.IsOnMission)
        {
            NpcCanvas.SetActive(true);
            NextText.enabled = true;

            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DialogueCounter <= Dialogues.Length)
                {
                    DialogueCounter++;
                }

            }

            if (DialogueCounter >= Dialogues.Length)
            {
                HasTalked = true;
            }

            if (!HasTalked)
            {
                DialogueText.text = Dialogues[DialogueCounter];

                NextText.text = pressE;
            }

            if (HasTalked)
            {
                NextText.text = "";
            }

        }
        else
        {
            if (doDesactivateOnce)
            {
                NpcCanvas.SetActive(false);
                doDesactivateOnce = false;
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnRange = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerOnRange = false;
            doDesactivateOnce = true;
            HasTalked = false;
            DialogueCounter = 0;
        }
    }

}
