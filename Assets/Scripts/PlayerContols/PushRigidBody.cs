using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushRigidBody : MonoBehaviour
{

    public float pushPower;//Fuerza con la que empuja

    private float targetMass; //Guarda la masa del objeto que empujo

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody; //Detecta el collider del objeto que tocamos y lo almacena en la variable 'body'

        if (body == null || body.isKinematic)
        {
            return; //No hace nada
        }

        if (hit.moveDirection.y < -0.3)//Si lo golpea desde arriba
        {
            return; //No hace nada
        }

        targetMass = body.mass;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);//Guarda la direccion a la que estamos empujando el objeto

        body.velocity = pushDir * pushPower / targetMass;
    }
}
