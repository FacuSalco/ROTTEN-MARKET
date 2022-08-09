using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barraVida;
    public float vidaActual;
    public int vidaMaxima;
    public Text vidaActualtxt;

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

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "5-Damage" || col.gameObject.tag == "Ground")
        {
            vidaActual -= 5;
            Debug.Log("-5 vida");
        }
    }

}
