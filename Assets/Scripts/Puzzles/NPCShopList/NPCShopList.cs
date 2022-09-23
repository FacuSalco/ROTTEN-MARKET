using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCShopList : MonoBehaviour
{
    public GameObject[] shopList; //Meter el objeto, no el empty
    public bool shopListFull;
    [SerializeField]int cantObjetosEntregados;
    GameObject objetoTraido;
    bool trajoObjeto;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shopList = GameObject.FindGameObjectsWithTag("ObjectNPCList"); //El tag va en el objeto, no el empty
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && trajoObjeto && player.GetComponent<PickUpObject>().PickedObject != null) //Si el player toca [E] y trajo un objeto de la lista y el player lo esta agarrando
        {
            objetoTraido.SetActive(false);
            cantObjetosEntregados++;
            trajoObjeto = false;
        }

        if (cantObjetosEntregados == shopList.Length)
        {
            shopListFull = true;
            Debug.Log("Me trajiste todos los objetos! Gracias");

        }
                
    }
    
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player") //Hacer un dialogo que el NPC te diga que se rompio la pierna y necesita que le traigas algunas cosas del super
        {
            Debug.Log("Hola Manzana, me podrías ayudar? Me lastime la pierna y debo buscar algunas cosas del supermercado, las buscarías por mi? Te pagare bien...\nNecesito que me traigas: OBJETOS DE LA LISTA");
        }

        for (int i = 0; i < shopList.Length; i++)
        {
            if (col.gameObject.name == shopList[i].name && col.transform.root.CompareTag("Player")) //Entra con objeto de la lista que el tag del padre es "Player", osea si lo tiene en la mano
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
    }

}
