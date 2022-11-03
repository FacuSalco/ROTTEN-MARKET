using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateButton : MonoBehaviour
//NO TRATAR DE USAR CON EL PLAYER PORQUE NO SE PUEDE :(

{
    public string ActivatorName;
    public bool pressed;
    public GameObject resultado;
    bool alreadyPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pressed == true && !alreadyPressed) //BOTON PRESIONADO
        {
            Debug.Log("Boton presionado");
            GetComponent<Renderer>().material.color = Color.green;
            transform.Translate(0, -0.2f, 0);
            resultado.GetComponent<Animator>().Play("AbrirPersian");
            //Dejar de reproducir la animacion de la persiana

            alreadyPressed = true;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == ActivatorName) //    -----     //Cambiarle a todos los props por el mismo nombre (No uso tag porque ya tienen el "CameraIgnore")
        {
            pressed = true;
        }
    }

}
