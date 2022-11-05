using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartHandler : MonoBehaviour
{
    private Vector3 PlayerSpawn;
    private GameObject Player;

    public bool HasRestarted = false;

    public void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerSpawn = Player.GetComponent<PlayerController1>().DefaultPos;

    }

    public void RespawnPlayer()
    {
        Player.transform.position = PlayerSpawn;
        HasRestarted = true;
    }

}
