using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {    
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
            Debug.Log("Agarro moneda");
            GetComponent<PlayerStats>().Data.cantMonedas++;
        }
    }

}
