using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArregloProblemaSpawn : MonoBehaviour
{
    [SerializeField] private GameObject GO, MAP;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GO = GameObject.Find("FRUTAS");
        MAP = GameObject.Find("EVERYTHING");

        Debug.Log(transform.position.x);
        if (transform.position.x > 300 && GO != null)
        {
            Debug.Log("Se ha reiniciado la posicion del objeto");
            MAP.transform.position = new Vector3(333.24f, -5f, 144.5F);
        }
    }
}
