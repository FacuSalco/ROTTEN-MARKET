using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using TMPro;

public class ChangeConfigs : MonoBehaviour
{
    
    public CinemachineFreeLook cineCam;
    [Header("SensX")]
    public float sensitivityX;
    public Slider sensXSlider;
    public TMP_Text sensXTxt;
    [Header("SensY")]
    public float sensitivityY;
    public Slider sensYSlider;
    public TMP_Text sensYTxt;
    [Header("Volume")]
    public float volume;
    public Slider volumeSlider;
    public TMP_Text volumeTxt;
    public Image VolOffImg;
    public GameObject VolOnImg;
    
    // Start is called before the first frame update
    void Start()
    {
        sensXSlider.value = sensitivityX / 10;
        sensYSlider.value = sensitivityY / 10;
        volumeSlider.value = volume / 100;
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
        volumeTxt.text = (volume * 100).ToString("0") + "%";
        sensXTxt.text = (sensitivityX * 10).ToString("F0");
        sensYTxt.text = (sensitivityY * 10).ToString("F0");
    }

    void RevisarSiEstaMute()
    { //Para cambiar la imagen del volumen
        if (volumeTxt.text == "0%")
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
