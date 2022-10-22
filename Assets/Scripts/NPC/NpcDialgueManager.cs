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
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NextText;
    public TextMeshProUGUI TimeTxt;
    public string pressE = "Presione ¨E¨ para continuar";

    [Header("Manager")]
    public npcScriptableObject DialogueManager;
    //Manager
    private int DialogueCounter = 0;
    private int DialogueAfterCounter = 0;
    private bool playerOnRange = false;
    private bool hasIntrodusedMission = false;
    private bool hasFinishedTalking = false;

    private bool hasStartedMission = false;
    private float TimeCounter, TimeDeltaCounter;
    public bool hasFailedMission = false;


    private PlayerStats playerStats;
    private ReciveCoins ReciveCoins;


    // Start is called before the first frame update
    void Start()
    {
        NpcCanvas.SetActive(false);
        MissionCanvas.SetActive(false);

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        ReciveCoins = GameObject.Find("[RECIVE-COINS]").GetComponent<ReciveCoins>();


        TimeDeltaCounter = DialogueManager.missionTime;
        TimeCounter = TimeDeltaCounter;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOnRange)
        {
            //Empieza a hablar
            NpcCanvas.SetActive(true);


            if (!hasIntrodusedMission)
            {
                DialogueText.text = DialogueManager.dialoguesBeforeMission[DialogueCounter];
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
                    //DialogueManager.hasDoneMission = true;
                }

            }
            //empezar mision
            if (DialogueManager.hasAcceptedMission && !DialogueManager.hasDoneMission)
            {
                StartMission();

                if (DialogueManager.missionHasTime)
                {
                    TimeTxt.text = Mathf.Round(TimeCounter).ToString();

                    if (!hasFailedMission)
                    {
                        TimeCounter -= Time.deltaTime;
                    }

                    if (TimeCounter < 0)
                    {
                        FailedMission();
                    }

                    if (hasFailedMission)
                    {
                        FailedTXT.SetActive(true);
                        FailedPanel.SetActive(true);
                    }
                }
                else
                {
                    TimeTxt.enabled = false;
                }
            }

            //Termino la misión

            if (DialogueManager.hasDoneMission)
            {
                
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
                    GiveReward();

                }

                //muestra el ultimo texto indefinidamente
                if (DialogueAfterCounter >= DialogueManager.dialoguesAfterMission.Length - 1)
                {
                    hasFinishedTalking = true;

                    DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueManager.dialoguesAfterMission.Length - 1];
                }

            }

        }
        else
        {
            NpcCanvas.SetActive(false);
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerOnRange = true;
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
        ReciveCoins.reciveCoins(coins); //CAMBIE ESTA POR OTRA QUE HICE AHORA PORQUE AGRUEGUE UNA MEJORA DE MONEDAS X2
    }

    public void StartMission()
    {
        DialogueCanvas.SetActive(false);
        MissionCanvas.SetActive(true);

    }

    public void FailedMission()
    {
        hasFailedMission = true;
    }

    public void CompleteMission()
    {
        DialogueManager.hasDoneMission = true;
        DialogueCanvas.SetActive(true);
        MissionCanvas.SetActive(false);
    }

    public void SetUpCanvas()
    {

    }

}
