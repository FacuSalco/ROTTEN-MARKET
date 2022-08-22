using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseBehaviour : MonoBehaviour
{
    public Canvas menuPausa;
    bool paused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }

        if (paused == true)
        {
            menuPausa.enabled = true;
        }

        else
        {
            menuPausa.enabled = false;
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        
        if (paused == false)
        {
            paused = true;
        }
        if (paused == true)
        {
            paused = false;
        }
    }
}

//Revisar que no estaria andando sacar pausa