using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barraVida;
    public static float vidaActual;
    public int vidaMaxima;
    public Text vidaActualtxt;
    static public bool immortal;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        
    }

    // Update is called once per frame
    void Update()
    {
        int iVidaActual = (int)System.Math.Floor(vidaActual); //Convertir el float a int
        barraVida.fillAmount = vidaActual / vidaMaxima;
        vidaActualtxt.text = (iVidaActual + "%");
    }

}
