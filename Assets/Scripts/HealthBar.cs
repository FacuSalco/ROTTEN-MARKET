using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //NO SOLO TIENE LA HEALTH-BAR. TAMBIEN TIENE LAS MONEDAS PARA MOSTRAR
    public GameObject playerCanvas;
    public Image barraVida;
    public float vidaActual;
    public int vidaMaxima;
    static public bool immortal;
    public int cantMonedas;
    public Text cantMonedasTxt;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        //playerCanvas.SetActive(true);
    }

// Update is called once per frame
void Update()
    {
        int iVidaActual = (int)System.Math.Floor(vidaActual); //Convertir el float a int
        barraVida.fillAmount = vidaActual / vidaMaxima;

        cantMonedas = GetComponent<PlayerStats>().Data.cantMonedas;
        //cantMonedasTxt.text = cantMonedas.ToString();

        if(vidaActual < 0)
        {
            //morir
        }

    }

    public void makeDamage(int damage)
    {

        vidaActual -= damage;
    }

}
