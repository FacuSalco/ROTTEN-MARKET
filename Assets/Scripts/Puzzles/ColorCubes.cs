using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubes : MonoBehaviour
{
    bool redOk, yellowOk, blueOk, allOk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VerifyOk();

        AllOk();

        Debug.Log("Azul: " + blueOk);
    }
    
    void OnCollisionStay(Collision col) //No se porque no lo detecta siempre.
    {
            if (col.gameObject.name == "CuboAzul" && gameObject.name == "PlatAzul")
            {
                blueOk = true;
                Debug.Log("Azul " + blueOk);
            }

            if (col.gameObject.name == "CuboRojo" && gameObject.name == "PlatRoja")
            {
                redOk = true;
                Debug.Log("Rojo " + redOk);
            }

            if (col.gameObject.name == "CuboAmarillo" && gameObject.name == "PlatAmarilla")
            {
                yellowOk = true;
                Debug.Log("Amarillo " + yellowOk);
            }
    }
    
    void VerifyOk()
    {
        if (redOk && yellowOk && blueOk)
        {
            allOk = true;
        }
    }

    void AllOk()
    {
        if (allOk)
        {
            Debug.Log("Lograste pasar el puzzle");
        }
    }

}
