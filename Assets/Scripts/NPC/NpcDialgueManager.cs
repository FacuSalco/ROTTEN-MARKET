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
    private bool playerOnRange;
    private bool hasIntrodusedMission = false;


    // Start is called before the first frame update
    void Start()
    {
        NpcCanvas.SetActive(false);

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

                DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueAfterCounter];

                if (DialogueAfterCounter >= DialogueManager.dialoguesAfterMission.Length)
                {
                    DialogueText.text = DialogueManager.dialoguesAfterMission[DialogueAfterCounter];
                }

            }

        }
        else
        {
            NpcCanvas.SetActive(false);
        }

        
    }

    void OnTriggerEnter()
    {
        playerOnRange = true;
    }

    void OnTriggerExit()
    {
        playerOnRange = false;
    }

    public void AceptedMission()
    {
        DialogueManager.hasDoneMission = true;
    }


}
