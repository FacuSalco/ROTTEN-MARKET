using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMapScene : MonoBehaviour
{
    bool isNear;
    public static bool returnedFromEntrance/*, entroAlDeposito*/, returnedFromExit/*, returnedFromDepositExit*/;
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
                Debug.Log("Bool returnedFromEntrance es " + returnedFromEntrance);
            }

            //if (gameObject.name == "EntradaDeposito")
            //{
            //    entroAlDeposito = true;
            //    Debug.Log("Bool entroAlDeposito es " + entroAlDeposito);
            //}
            
            if (gameObject.name == "VolverSuperSalida")
            {
                returnedFromExit = true;
                Debug.Log("Bool returnedFromExit es " + returnedFromExit);
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
        if (gameObject.name == "EntradaDeposito")
        {
            SceneManager.LoadScene("DepositScene");
            Fade.FadeIn();
            Debug.Log("Entrando al deposito...");
        }
        
        else
        {
            SceneManager.LoadScene("MapScene");
            Fade.FadeIn();
            Debug.Log("Entrando al mapa...");
        }
    }

}

