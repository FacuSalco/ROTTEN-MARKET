using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ChangeConfigs : MonoBehaviour
{
    public CinemachineFreeLook cineCam;
    public float sensitivityX, sensitivityY, volume;
    public Slider volumeSlider, sensXSlider, sensYSlider;
    public Image VolOffImg;
    public TMP_Text VolNumber, XSensNumber, YSensNumber;
    public GameObject VolOnImg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sensitivityX = sensXSlider.value;
        sensitivityY = sensYSlider.value;
        cineCam.m_XAxis.m_MaxSpeed = 35f * sensitivityX;
        cineCam.m_YAxis.m_MaxSpeed = sensitivityY / 3.3f;

        AudioListener.volume = volumeSlider.value;

        volume = volumeSlider.value;

        RevisarSiEstaMute();
        //Mostrar sin decimales
        VolNumber.text = (volume * 100).ToString("0") + "%";
        XSensNumber.text = (sensitivityX * 10).ToString("F0");
        YSensNumber.text = (sensitivityY * 10).ToString("F0");
    }

    void RevisarSiEstaMute()
    { //Para cambiar la imagen del volumen
        if (VolNumber.text == "0%")
        {
            volumeSlider.value = 0;
            VolOffImg.enabled = true;
            VolOnImg.SetActive(false);
        }

        else
        {
            VolOffImg.enabled = false;
            VolOnImg.SetActive(true);
        }
    }

    public void Mute()
    {
        volumeSlider.value = 0;
    }

}
