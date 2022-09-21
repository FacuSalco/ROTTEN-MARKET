using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ChangeConfigs : MonoBehaviour
{
    public CinemachineFreeLook cineCam;
    public float sensitivityX, sensitivityY;
    public Slider volumeSlider, sensXSlider, sensYSlider;
    public Image VolOnImg, VolOffImg;
    public TMP_Text VolNumber, XSensNumber, YSensNumber;

    // Start is called before the first frame update
    void Start()
    {
        AudioListener.volume = volumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        sensitivityX = sensXSlider.value;
        sensitivityY = sensYSlider.value;
        cineCam.m_XAxis.m_MaxSpeed = 35f * sensitivityX;
        cineCam.m_YAxis.m_MaxSpeed = sensitivityY / 3.3f;

        AudioListener.volume = volumeSlider.value;
        RevisarSiEstaMute();
        //Mostrar sin decimales
        VolNumber.text = (volumeSlider.value * 100).ToString("0") + "%";
        XSensNumber.text = (sensitivityX * 10).ToString("F0");
        YSensNumber.text = (sensitivityY * 10).ToString("F0");
    }

    void RevisarSiEstaMute()
    { //Para cambiar la imagen del volumen
        if (volumeSlider.value == 0)
        {
            VolOffImg.enabled = true;
            VolOnImg.enabled = false;
        }

        else
        {
            VolOffImg.enabled = false;
            VolOnImg.enabled = true;
        }
    }
}
