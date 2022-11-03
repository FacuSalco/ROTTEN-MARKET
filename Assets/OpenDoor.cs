using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    bool isNear, openedDoor;
    GameObject player;
    public GameObject leftDoor, rightDoor;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear && player.GetComponent<PickUpObject>().PickedObject.name == "Destornillador" && !openedDoor)
        {
            player.GetComponent<PickUpObject>().PickedObject.SetActive(false);
            openedDoor = true;
            Debug.Log("Se abrio la puerta");
            //Hacer la animacion que se abre la puerta
            leftDoor.GetComponent<Animator>().Play("OpenLeftDoor");
            rightDoor.GetComponent<Animator>().Play("OpenRightDoor");
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            isNear = true;
        }
    }




}
