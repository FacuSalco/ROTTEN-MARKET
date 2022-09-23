using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balanza : MonoBehaviour
{
    public float pesoOk, pesoActual;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (pesoOk == pesoActual)
        {
            Debug.Log("Llego al peso requerido, " + pesoOk + "kg");
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        float colMasa = rb.mass;
        pesoActual += colMasa;

    }

    void OnCollisionExit(Collision col)
    {
        Rigidbody rb = col.gameObject.GetComponent<Rigidbody>();
        float colMasa = rb.mass;
        pesoActual -= colMasa;
    }



}
