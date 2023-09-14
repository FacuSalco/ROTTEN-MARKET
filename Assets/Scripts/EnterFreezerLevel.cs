using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFreezerLevel : MonoBehaviour
{
    bool isNear;
    Fade Fade;
    public PlayerData Data;
    [SerializeField] private GameObject NpcCanvas;
    //[SerializeField] private GameObject MAP;


    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Panel").GetComponent<Fade>();
        NpcCanvas = GameObject.Find("NpcCanvas");
        //MAP = GameObject.Find("EVERYTHING");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear) //Entra al nivel Freezer
        {
            Fade.FadeOut();
            //NpcCanvas.SetActive(false);
            Debug.Log("NPC Canvas off");
            if (Data.playerJumpForce < 20)
            {
                Data.playerJumpForce = 20;
            }
            Invoke("ChangeScene", 2);
        }
    }
    
    private void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            isNear = true;
            gameObject.GetComponentInChildren<Canvas>().enabled = true;
        }
    }
    
    void OnTriggerExit (Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = false;
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
        }
    }
    
    void ChangeScene()
    {
        SceneManager.LoadScene("FreezerScene");
        Fade.FadeIn();
        //MAP.transform.position = new Vector3(0,0,0);
    }

}

