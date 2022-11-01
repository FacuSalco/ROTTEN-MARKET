using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class ReturnedFromFreezerSpawn : MonoBehaviour
{
    public GameObject SpawnAfterWin, SpawnBeforeWin/*, SpawnInDepositEntrance, SpawnInDepositExit*/;
    GameObject player;
    
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (ReturnMapScene.returnedFromEntrance)
        {
            SpawnPlayerBeforeWin();
            ReturnMapScene.returnedFromEntrance = false;
        }

        if (ReturnMapScene.returnedFromExit)
        {
            SpawnPlayerAfterWin();
            ReturnMapScene.returnedFromExit = false;
        }

        //if (ReturnMapScene.entroAlDeposito)
        //{
        //    SpawnPlayerInDepositEntrace();
        //    ReturnMapScene.entroAlDeposito = false;
        //}
        
        

    }

    // Update is called once per frame
    void Update()
    {
    }
    
    public void SpawnPlayerAfterWin()
    {
        player.transform.position = SpawnAfterWin.transform.position;
        player.transform.eulerAngles = SpawnAfterWin.transform.eulerAngles;        
        //Debug.Log("Spawn Salida");
    }
    
    public void SpawnPlayerBeforeWin()
    {
        player.transform.position = SpawnBeforeWin.transform.position;
        player.transform.eulerAngles = SpawnBeforeWin.transform.eulerAngles;
    }
    
    public void SpawnPlayerInDepositEntrace()
    {
        player.transform.position = new UnityEngine.Vector3(119.59f, 147.7f, -111.52f);
        //player.transform.eulerAngles = SpawnInDepositEntrance.transform.eulerAngles;
    }

}
