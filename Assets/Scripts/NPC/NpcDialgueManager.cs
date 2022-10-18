using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NpcDialgueManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject NpcCanvas;
    public TextMeshProUGUI DialogueText;
    public TextMeshProUGUI NextText;
    public string pressE = "Presione ¨E¨ para continuar";

    [Header("Manager")]
    public npcScriptableObject DialogueManager;
    private int DialogueCounter = 0;
    private int DialogueAfterCounter = 0;
    private bool playerOnRange = false;
    private bool hasIntrodusedMission = false;
    private bool hasFinishedTalking = false;

    private PlayerStats playerStats;


    // Start is called before the first frame update
    void Start()
    {
        NpcCanvas.SetActive(false);

        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
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
                    DialogueManager.hasDoneMission = true;
                }

            }
            if (DialogueManager.hasAcceptedMission && !DialogueManager.hasDoneMission)
            {
                //empezar mision

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
        playerStats.Data.addCoins(coins);
    }


}
