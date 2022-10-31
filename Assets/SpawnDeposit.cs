using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class SpawnDeposit : MonoBehaviour
{
    public GameObject SpawnInDepositEntrance;
    GameObject player;

    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        //if (ReturnMapScene.entroAlDeposito)
        //{
        //    SpawnPlayerInDepositEntrace();
        //    ReturnMapScene.entroAlDeposito = false;
        //}

        SpawnPlayerInDepositEntrace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnPlayerInDepositEntrace()
    {
        player.transform.position = new UnityEngine.Vector3(119.59f, 147.7f, -111.52f);
        player.transform.eulerAngles = SpawnInDepositEntrance.transform.eulerAngles;
    }

}
