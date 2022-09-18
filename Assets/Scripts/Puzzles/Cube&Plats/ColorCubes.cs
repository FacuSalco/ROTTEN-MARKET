using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubes : MonoBehaviour
{
    public bool isOk = false;

    public GameObject cube;

    public ColorCubeManager CCM;

    void OnCollisionStay(Collision col)
    {
        if(col.gameObject == cube)
        {
            GetPressed();
        }
    }

    void OnCollisionExit (Collision col)
    {
        isOk = false;
        //Logica de cuando se saca un cubo
        CCM.cuboGanador.SetActive(false);//Sacar esto si no quiero que cambie algo si saco un cubo
    }

    void GetPressed()
    {
        isOk = true;
        Debug.Log(gameObject.name + " " + isOk);
        CCM.CubeIsPressed(this);
    }
}