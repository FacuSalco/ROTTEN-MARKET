using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Si colisiona con un objeto que se llama "CuboPuzzle" y tienen el mismo material este se destruye

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "CuboPuzzle" && col.gameObject.GetComponent<Renderer>().material == GetComponent<Renderer>().material)
        {
            Debug.Log("Colisiono"); //No se porque pero no anda
        }
    }

}
