using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveCoins : MonoBehaviour
{
    public PlayerData Data;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    

    public void reciveCoins(int coins)
    {
        if (Data.x2Coins)
        {
            Data.cantMonedas += coins * 2;
        }

        else
        {
            Data.cantMonedas += coins;
        }
    }

}
