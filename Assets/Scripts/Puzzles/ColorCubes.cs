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
    }

    void GetPressed()
    {
        isOk = true;
        Debug.Log(gameObject.name + " " + isOk);
        CCM.CubeIsPressed(this);
    }
}