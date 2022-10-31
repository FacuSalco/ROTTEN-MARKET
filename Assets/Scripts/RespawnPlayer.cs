using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlayer : MonoBehaviour
{
    GameObject player;
    public Vector3 respawn;
    GameObject respawner;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        respawner = GameObject.FindGameObjectWithTag("Respawn");
        respawn = respawner.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            player.transform.position = respawn;
            Debug.Log("RespawnPlayer");
        }
    }
}
