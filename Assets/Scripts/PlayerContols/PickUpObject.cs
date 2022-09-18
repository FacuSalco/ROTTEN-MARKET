using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject;
    public Transform interactionZone; //Ubicacion donde quiero que quede agarrado el objeto
    

    // Update is called once per frame
    void Update()
    {
        if (ObjectToPickUp != null && ObjectToPickUp.GetComponent<PickableObject>().isPickable == true && PickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))//Si toco la F suceda lo de abajo
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable = false; //Le avisamos que ya agarramos el objeto
                PickedObject.transform.SetParent(interactionZone); //Lo parenteamos
                PickedObject.transform.position = interactionZone.position;//Lo ponemos en la posicion de la zona de interaccion o donde queramos
                PickedObject.GetComponent<Rigidbody>().useGravity = false; //Para que lo agarremos y no se nos caiga
                PickedObject.GetComponent<Rigidbody>().isKinematic = true; //Para que no le afecte la fisica
                ObjectToPickUp.GetComponent<PickableObject>().isPicked = true;
            }
        }

        else if (PickedObject != null) //Si ya agarramos algo
        {
            if (Input.GetKeyDown(KeyCode.F)) //para soltar
            {
                PickedObject.GetComponent<PickableObject>().isPickable = true;
                PickedObject.transform.SetParent(null);
                PickedObject.transform.position = interactionZone.position;
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                PickedObject = null;
                ObjectToPickUp.GetComponent<PickableObject>().isPicked = false;
            }
        }
    }
}
