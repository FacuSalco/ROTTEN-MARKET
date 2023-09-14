using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchPosition : MonoBehaviour
{
    [SerializeField]
    private Transform objetoObjetivo;

    [SerializeField]
    private Vector3 offset = Vector3.zero;

    private void Update()
    {
        if (objetoObjetivo != null)
        {
            // Mantén la posición del objeto actual igual a la del objeto objetivo más el offset
            transform.position = objetoObjetivo.position + offset;
        }
        else
        {
            Debug.LogWarning("El objeto objetivo no está asignado. Asigna un objeto en el Inspector.");
        }
    }
}





