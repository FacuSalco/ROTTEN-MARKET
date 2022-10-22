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
    GameObject objetoTraido;
    bool trajoObjeto;
    GameObject player;
    SFXManager SFX;
    public GameObject shopListCanvas;
    public Image[] shopListImages;
    public PlayerData Data;
    ReciveCoins ReciveCoins;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trajoObjeto && player.GetComponent<PickUpObject>().PickedObject != null && startedQuest) //Si el player toca [E] y trajo un objeto de la lista y el player lo esta agarrando
        {
            objetoTraido.SetActive(false);
            cantObjetosEntregados++;
            trajoObjeto = false;

            if (objetoTraido.name == "Fork")
            {
                shopListImages[0].GetComponent<Image>().color = Color.green;
            }

            if (objetoTraido.name == "Knife")
            {
                shopListImages[1].GetComponent<Image>().color = Color.green;
            }

            if (objetoTraido.name == "Spoon")
            {
                shopListImages[2].GetComponent<Image>().color = Color.green;
            }

        }

        if (cantObjetosEntregados == shopList.Length && !finishedQuest) //COMPLETO LA QUEST
        {
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

        if (nearNPC && Input.GetKeyDown(KeyCode.E) && !startedQuest && !finishedQuest) //Si el player toca [E] y no empezó la quest y no la terminó. ACEPTA LA QUEST
        {
            startedQuest = true;
            shopListCanvas.SetActive(true);
            Debug.Log("Empezaste la quest");
        }


    }
    
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player") //Hacer un dialogo que el NPC te diga que se rompio la pierna y necesita que le traigas algunas cosas del super
        {
            Debug.Log("Hola Manzana, me podrías ayudar? Me lastime la pierna y debo buscar algunas cosas del supermercado, las buscarías por mi? Te pagare bien..." +
            "\nNecesito que me traigas: Un tenedor, un cuchillo y una cuchara. \n[Presiona E para aceptar la mision]");
            nearNPC = true;
        }

        for (int i = 0; i < shopList.Length; i++)
        {
            if (col.gameObject == shopList[i] && col.transform.root.CompareTag("Player")) //Entra con objeto de la lista que el tag del padre es "Player", osea si lo tiene en la mano
            {
                trajoObjeto = true;
                objetoTraido = shopList[i];
            }
            
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

    void CoinReward()
    {
        SFX.PlayCoinSound();
        ReciveCoins.reciveCoins(coinReward);
    }

}
