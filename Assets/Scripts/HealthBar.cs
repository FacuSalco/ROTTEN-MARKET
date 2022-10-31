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
    public GameObject thirdPersonCamera;
    SFXManager SFX;
    static bool isDead;
    public GameObject DañoVignette;

    // Start is called before the first frame update
    void Start()
    {
        vidaActual = vidaMaxima;
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();
        isDead = false;
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
        //cantMonedasTxt.text = cantMonedas.ToString();


        //MUERTE
        if (vidaActual <= 0 && !isDead)
        {
            isDead = true;
            SFX.PlayDeathSound();
            Debug.Log("Muerio");
        }

    }

    //HACER DAÑO AL PLAYER
    public void makeDamage(int damage)
    {
        if (GetComponent<PlayerStats>().Data.immortal == false)
        {
            DañoVignette.SetActive(false);
            GetComponent<PlayerStats>().Data.playerHealth -= damage;
            SFX.PlayHitSound();
            DañoVignette.SetActive(true);

            Invoke("DesactivateVignette", 0.3f);

        }
    }

    void DesactivateVignette()
    {
        DañoVignette.SetActive(false);
    }



}
