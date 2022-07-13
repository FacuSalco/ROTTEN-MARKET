﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barraVida;
    public float vidaActual;
    public float vidaMaxima;
    public Text vidaActualtxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barraVida.fillAmount = vidaActual / vidaMaxima;
        vidaActualtxt.text = (vidaActual + "%");
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "5-Damage")
        {
            vidaActual -= 5;
            Debug.Log("-5 vida");
        }
    }

}