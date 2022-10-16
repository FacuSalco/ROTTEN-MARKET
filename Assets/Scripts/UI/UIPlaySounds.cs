using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlaySounds : MonoBehaviour
{
    SFXManager SFX;

    // Start is called before the first frame update
    void Start()
    {
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayClickSound()
    {
        SFX.PlayClickSound();
    }
    public void PlayClickErrorSound()
    {
        SFX.PlayClickErrorSound();
    }

}
