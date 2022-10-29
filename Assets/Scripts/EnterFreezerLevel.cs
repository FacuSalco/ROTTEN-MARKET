using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterFreezerLevel : MonoBehaviour
{
    bool isNear;
    Fade Fade;

    // Start is called before the first frame update
    void Start()
    {
        Fade = GameObject.Find("Panel").GetComponent<Fade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear) //Entra al nivel Freezer
        {
            Fade.FadeOut();
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
    }

}

