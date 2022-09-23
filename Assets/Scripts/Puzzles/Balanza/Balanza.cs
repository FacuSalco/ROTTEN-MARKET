using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balanza : MonoBehaviour
{
    public GameObject[] wheightThings;
    public int pesoOk, pesoActual;

    // Start is called before the first frame update
    void Start()
    {
        wheightThings = GameObject.FindGameObjectsWithTag("ThingKG");
    }

    // Update is called once per frame
    void Update()
    {
        if (pesoOk == pesoActual)
        {
            Debug.Log("Llego al peso requerido, " + pesoOk + "kg");
        }
    }

    void OnColliderEnter(Collider col)
    {
        for (int i = 0; i < wheightThings.Length; i++)
        {
            if (col.gameObject.name == wheightThings[i].name) //Si es un objeto de los que tienen peso...
            {
                pesoActual += int.Parse(wheightThings[i].name);
                Debug.Log("Agrego " + wheightThings[i].name + "kg" + ", ahora el peso esta en " + pesoActual);
            }

        }
    }

}
