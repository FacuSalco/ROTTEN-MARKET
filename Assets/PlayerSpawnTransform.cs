using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnTransform : MonoBehaviour
{
    private Vector3 defaultPos;
    private Vector3 defaultRot;
    GameObject player;
    

    // Start is called before the first frame update
    void Awake()
    {
        defaultPos = gameObject.transform.position;
        defaultRot = gameObject.transform.eulerAngles;
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = defaultPos;
        player.transform.eulerAngles = defaultRot;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
