using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCShopList : MonoBehaviour
{
    public GameObject[] shopList; //Meter el objeto, no el empty
    public bool finishedQuest, startedQuest, talkedToNPC, nearNPC;
    public int coinReward; //PONERLA DIVIDIDO POR 6
    [SerializeField]int cantObjetosEntregados;
    public GameObject objetoTraido;
    bool trajoObjeto, trajoTenedor, trajoCuchillo, trajoCuchara, trajoSalero, trajoCerezas;
    GameObject player;
    SFXManager SFX;
    public GameObject shopListCanvas;
    public Image[] shopListImages;
    public PlayerData Data;
    ReciveCoins ReciveCoins;
    private NpcDialgueManager NpcManager;

    //Tenedor (fork) es el shopList[0]
    //Cuchillo (knife) es el shopList[1]
    //Cuchara (spoon) es el shopList[2]

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //shopList = GameObject.FindGameObjectsWithTag("ObjectNPCList"); //El tag va en el objeto, no el empty
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
        ReciveCoins = GameObject.Find("[RECIVE-COINS]").GetComponent<ReciveCoins>();
        NpcManager = GetComponent<NpcDialgueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trajoObjeto && player.GetComponent<PickUpObject>().PickedObject != null && startedQuest && !finishedQuest) //Si el player toca [E] y trajo un objeto de la lista y el player lo esta agarrando
        {

            if (objetoTraido.name == "Fork" && !trajoTenedor)
            {
                shopListImages[0].GetComponent<Image>().color = Color.green;
                objetoTraido.SetActive(false);
                cantObjetosEntregados++;
                trajoObjeto = false;
                trajoTenedor = true;
            }

            if (objetoTraido.name == "Knife" && !trajoCuchillo)
            {
                shopListImages[1].GetComponent<Image>().color = Color.green;
                objetoTraido.SetActive(false);
                cantObjetosEntregados++;
                trajoObjeto = false;
                trajoCuchillo = true;
            }

            if (objetoTraido.name == "Spoon" && !trajoCuchara)
            {
                shopListImages[2].GetComponent<Image>().color = Color.green;
                objetoTraido.SetActive(false);
                cantObjetosEntregados++;
                trajoObjeto = false;
                trajoCuchara = true;
            }

            if (objetoTraido.name == "Salero" && !trajoSalero)
            {
                shopListImages[3].GetComponent<Image>().color = Color.green;
                objetoTraido.SetActive(false);
                cantObjetosEntregados++;
                trajoObjeto = false;
                trajoSalero = true;
            }

            if (objetoTraido.name == "Cereza" && !trajoCerezas)
            {
                shopListImages[4].GetComponent<Image>().color = Color.green;
                objetoTraido.SetActive(false);
                cantObjetosEntregados++;
                trajoObjeto = false;
                trajoCerezas = true;
            }

        }

        if (cantObjetosEntregados == shopList.Length && !finishedQuest) //COMPLETO LA QUEST
        {
            NpcManager.CompleteMission();
            finishedQuest = true;
            Debug.Log("Me trajiste todos los objetos! Gracias");
            SFX.PlayQuestCompleteSound();

            //player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<PlayerController1>().enabled = false; //Desactiva el script del player y no se puede mover
            Invoke("EnablePlayer", 5f); //Espera los segundos que le decis y llama a la funcion. En este caso, 5 segundos y llama a EnablePlayer

            //InvokeRepeating("CoinReward", 4f, 0.2f); //Espera los segundos que le decis y llama a la funcion cada x segundos. En este caso, 4 segundos y llama a CoinReward cada 0.2 segundos
            
            Invoke ("CoinReward", 4 );
            Invoke ("CoinReward", 4.2f );
            Invoke ("CoinReward", 4.4f );
            Invoke ("CoinReward", 4.6f );
            Invoke ("CoinReward", 4.8f );
            Invoke ("CoinReward", 5 );


        }

        if (nearNPC && NpcManager.DialogueManager.hasAcceptedMission && !startedQuest && !finishedQuest) //Si el player toca [E] y no empezó la quest y no la terminó. ACEPTA LA QUEST
        {
            startedQuest = true;
            shopListCanvas.SetActive(true);
            Debug.Log("Empezaste la quest");
            talkedToNPC = true;
        }

        if (NpcManager.hasFailedMission)
        {
            RestartQuest();
        }

    }
    
    void OnTriggerStay(Collider col)
    {
        for (int i = 0; i < shopList.Length; i++)
        {
            if (col.gameObject.name == shopList[i].name /*&& col.transform.root.CompareTag("Player") //Esta parte no anda porque el root ya no es el player, es el Persistent Object. Shhh */) //Entra con objeto de la lista que el tag del padre es "Player", osea si lo tiene en la mano
            {
                trajoObjeto = true;
                //objetoTraido = shopList[i];
                objetoTraido = col.gameObject;
            }            
        }
        
    }

    void OnTriggerEnter (Collider col)
    {
        if (col.gameObject.tag == "Player") //Hacer un dialogo que el NPC te diga que se rompio la pierna y necesita que le traigas algunas cosas del super
        {
            nearNPC = true;
        }        
    }

    void OnTriggerExit(Collider col)
    {
        for (int i = 0; i < shopList.Length; i++)
        {
            if (col.gameObject.name == shopList[i].name && col.transform.root.CompareTag("Player")) //Sale con objeto de la lista en mano
            {
                trajoObjeto = false;
                objetoTraido = null;
            }
        }

        if (col.gameObject.tag == "Player")
        {
            nearNPC = false;
        }
    }

    void EnablePlayer() //Para volver a permiterle al player moverse
    {
        player.GetComponent<PlayerController1>().enabled = true;
        //player.GetComponent<CharacterController>().enabled = true;
        shopListCanvas.SetActive(false);
    }

    private void RestartQuest()
    {
        for(int i = 0; i < shopListImages.Length; i++)
        {
            shopListImages[i].GetComponent<Image>().color = Color.white;
        }
        trajoObjeto = false;
        trajoCerezas = false;
        trajoCuchara = false;
        trajoCuchillo = false;
        trajoSalero = false;
        trajoTenedor = false;


        finishedQuest = false;
        startedQuest = false;
        talkedToNPC = false;

        cantObjetosEntregados = 0;

        shopListCanvas.SetActive(false);

}

void CoinReward()
    {
        SFX.PlayCoinSound();
        ReciveCoins.reciveCoins(coinReward);
    }

}
