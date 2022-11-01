using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcDialgueManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject NpcCanvas;
    public GameObject DialogueCanvas;
    public GameObject MissionCanvas;
    public GameObject FailedTXT;
    public GameObject FailedPanel;
    public GameObject RestartTxt;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NextText;
    public TextMeshProUGUI TimeTxt;
    public GameObject TimePanel;
    public string pressE = "Presione ¨E¨ para continuar";

    [Header("Manager")]
    public npcScriptableObject DialogueManager;
    //Manager
    private int DialogueCounter = 0;
    private int DialogueAfterCounter = 0;
    private bool playerOnRange = false;
    private bool hasIntrodusedMission = false;
    public bool hasFinishedTalking = false;

    private bool hasStartedMission = false;
    private float TimeCounter, TimeDeltaCounter;
    public bool hasFailedMission = false;

    private bool doDesactivateOnce = true;
    private bool doSetTimeOnce = true;

    private PlayerStats playerStats;
    private ReciveCoins ReciveCoins;
    private GameObject Player;
    private Vector3 PlayerRespawnPos;
    private MissionHandler MissionHand;
    private MissionStateChecker MissionChecker;

    private Animator NpcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        NpcCanvas.SetActive(false);
        MissionCanvas.SetActive(false);

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        //ReciveCoins = GameObject.Find("[RECIVE-COINS]").GetComponent<ReciveCoins>();
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerRespawnPos = Player.GetComponent<PlayerController1>().DefaultPos;
        MissionHand = GameObject.Find("[MISSION-MANAGER]").GetComponent<MissionHandler>();
        MissionChecker = MissionHand.GetComponent<MissionStateChecker>();
        NpcAnimator = GetComponent<Animator>();

        DialogueManagerSetUp();
        TimeSetUp();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnRange && !MissionHand.IsOnMission)
        {
            //Empieza a hablar
            NpcCanvas.SetActive(true);
            if (NpcAnimator)
            {
                NpcAnimator.SetBool("IsTalking", true);
            }

            if (!hasIntrodusedMission)
            {
                DialogueText.text = DialogueManager.dialoguesBeforeMission[DialogueCounter];
                NextText.enabled = true;
                NextText.text = pressE;
                
            }

            //Pasa los dialogos
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (DialogueCounter <= DialogueManager.dialoguesBeforeMission.Length)
                {
                   DialogueCounter++;
                }

                if(DialogueAfterCounter <= DialogueManager.dialoguesAfterMission.Length && DialogueManager.hasDoneMission)
                {
                    DialogueAfterCounter++;
                }
            }

            if(DialogueCounter >= DialogueManager.dialoguesBeforeMission.Length)
            {
                DialogueManager.hasTalked = true;
            }

            if (DialogueManager.hasTalked && !DialogueManager.hasAcceptedMission)
            {
                DialogueText.text = DialogueManager.mission;
                hasIntrodusedMission = true;
            }

            //Le da la misión

            if (hasIntrodusedMission && !DialogueManager.hasAcceptedMission)
            {
                NextText.text = "Presione ¨R¨ para aceptar la misión";
                if (Input.GetKeyDown(KeyCode.R))
                {
                    DialogueManager.hasAcceptedMission = true;
                    NextText.text = "";
                    MissionHand.StartMission();
                    //DialogueManager.hasDoneMission = true;
                }

            }
            //empezar mision
            if (DialogueManager.hasAcceptedMission && !DialogueManager.hasDoneMission)
            {
                StartMission();
            }

            //Termino la misión

            if (DialogueManager.hasDoneMission && !hasFinishedTalking)
            {
                bool DoOnce = true;

                DialogueCanvas.SetActive(true);
                MissionCanvas.SetActive(false);

                if (DoOnce)
                {
                    MissionChecker.CompletedMission();
                    MissionHand.IsOnMission = false;


                    DoOnce = false;
                }

                NextText.text = pressE;
                //DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueManager.dialoguesAfterMission.Length - 1];

                //muestra los textos hasta el anteultimo
                if(DialogueAfterCounter < DialogueManager.dialoguesAfterMission.Length && !hasFinishedTalking)
                {
                    DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueAfterCounter];
                }

                //da la recompensa
                if (DialogueAfterCounter >= DialogueManager.dialoguesAfterMission.Length - 2)
                {
                    bool doOnce = true;

                    if (doOnce)
                    {
                        GiveReward();
                        doOnce = false;
                    }


                }

                //muestra el ultimo texto indefinidamente
                if (DialogueAfterCounter >= DialogueManager.dialoguesAfterMission.Length - 1)
                {
                    hasFinishedTalking = true;
                    NextText.enabled = false;
                    DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueManager.dialoguesAfterMission.Length - 1];
                }

            }

        }
        else
        {
            if (NpcAnimator)
            {
                NpcAnimator.SetBool("IsTalking", false);
            }
            if (hasStartedMission)
            {
                DialogueCanvas.SetActive(false);
            }
            else
            {
                if (doDesactivateOnce && !MissionHand.IsOnMission)
                {
                    NpcCanvas.SetActive(false);
                    doDesactivateOnce = false;
                }
            }
        }



        if (DialogueManager.missionHasTime && hasStartedMission)
        {

            TimeTxt.text = Mathf.Round(TimeCounter).ToString();

            if (DialogueManager.hasAcceptedMission && !DialogueManager.hasDoneMission && !hasFailedMission)
            {
                TimeCounter -= Time.deltaTime;
            }

            if (TimeCounter < 0)
            {
                FailedMission();
            }

            if (hasFailedMission)
            {
                bool TrueFalse = true;
                FailedMissionActivation(TrueFalse);

                if (Input.GetKeyDown(KeyCode.R))
                {
                    PlayerRespawn();
                }
            }
        }
        else
        {
            //TimeTxt.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOnRange = true;
            doDesactivateOnce = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOnRange = false;
        }
    }

    public void GiveReward()
    {
        int coins = DialogueManager.coinReward;
        Debug.Log("added " + coins + "coins");
        //ReciveCoins.reciveCoins(coins); //CAMBIE ESTA POR OTRA QUE HICE AHORA PORQUE AGRUEGUE UNA MEJORA DE MONEDAS X2
    }

    public void StartMission()
    {
        DialogueCanvas.SetActive(false);
        MissionCanvas.SetActive(true);

        TimePanel.SetActive(true);
        TimeTxt.enabled = true;
        

        hasStartedMission = true;
        MissionHand.StartMission();
    }

    public void FailedMission()
    {
        hasFailedMission = true;
        MissionHand.IsOnMission = false;
    }

    public void CompleteMission()
    {
        DialogueManager.hasDoneMission = true;
        MissionHand.IsOnMission = false;
    }

    public void RestartMission()
    {
        DialogueManager.hasTalked = false;
        DialogueManager.hasAcceptedMission = false;
        hasFailedMission = false;
        hasStartedMission = false;
        hasIntrodusedMission = false;
        hasFinishedTalking = false;
        MissionHand.IsOnMission = false;


        DialogueCanvas.SetActive(true);

        TimeSetUp();
        CounterSetUp();
        DesactivateTimeUI();

        bool TrueFalse = false;
        FailedMissionActivation(TrueFalse);

    }

    public void DialogueManagerSetUp()
    {
        DialogueManager.hasTalked = false;
        DialogueManager.hasAcceptedMission = false;
        DialogueManager.hasDoneMission = false;
    }

    public void TimeSetUp()
    {
        TimeDeltaCounter = DialogueManager.missionTime;
        TimeCounter = TimeDeltaCounter;
    }

    public void CounterSetUp()
    {
        DialogueAfterCounter = 0;
        DialogueCounter = 0;
    }

    public void FailedMissionActivation(bool TrueFalse)
    {
        if (TrueFalse == true)
        {
            FailedTXT.SetActive(true);
            FailedPanel.SetActive(true);
            RestartTxt.SetActive(true);
        }

        if (TrueFalse == false)
        {
            FailedTXT.SetActive(false);
            FailedPanel.SetActive(false);
            RestartTxt.SetActive(false);
        }

    }

    public void DesactivateTimeUI()
    {
        TimePanel.SetActive(false);
        TimeTxt.enabled = false;
    }

    public void DesactivateDialogueUI()
    {
        NpcCanvas.SetActive(false);
    }

    public void PlayerRespawn()
    {
        Player.transform.position = PlayerRespawnPos;
        RestartMission();
    }
}
