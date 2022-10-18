using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaySounds : MonoBehaviour
{
    SFXManager SFX;
    CursorManager cursorManager;

    // Start is called before the first frame update
    void Start()
    {
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
        cursorManager = GameObject.Find("[CURSOR-MANAGER]").GetComponent<CursorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        SFX.PlayClickSound();
        cursorManager.OnButtonCursorExit();
    }
    public void PlayClickErrorSound()
    {
        SFX.PlayClickErrorSound();
        cursorManager.OnButtonCursorExit();
    }

}
