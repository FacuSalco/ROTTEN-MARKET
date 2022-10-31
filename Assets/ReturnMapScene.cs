using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMapScene : MonoBehaviour
{
    bool isNear;
    public static bool returnedFromEntrance, returnedFromExit;
    Fade Fade;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Panel").GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear) //Cambiar a la escena del mapa del supermercado
        {
            Fade.FadeOut();
            Invoke("ChangeScene", 2);
            
            if (gameObject.name == "VolverSuperEntrada")
            {
                returnedFromEntrance = true;
            }
            
            if (gameObject.name == "VolverSuperSalida")
            {
                returnedFromExit = true;
            }

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

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = false;
            gameObject.GetComponentInChildren<Canvas>().enabled = false;
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("MapScene");
        Fade.FadeIn();
    }

}

