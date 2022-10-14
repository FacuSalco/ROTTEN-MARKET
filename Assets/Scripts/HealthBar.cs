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
    public float vidaMaxima;
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
        //VIDA MAXIMA
        vidaMaxima = GetComponent<PlayerStats>().Data.playerMaxHealth;

        //VIDA ACTUAL
        int iVidaActual = (int)System.Math.Floor(vidaActual); //Convertir el float a int
        barraVida.fillAmount = vidaActual / vidaMaxima;
        vidaActual = GetComponent<PlayerStats>().Data.playerHealth;

        //MONEDAS
        cantMonedas = GetComponent<PlayerStats>().Data.cantMonedas;
        cantMonedasTxt.text = cantMonedas.ToString();


        //MUERTE
        if (vidaActual <= 0)
        {
            //morir
        }

    }

    //HACER DAÑO AL PLAYER
    public void makeDamage(int damage)
    {
        GetComponent<PlayerStats>().Data.playerHealth -= damage;
    }

}
