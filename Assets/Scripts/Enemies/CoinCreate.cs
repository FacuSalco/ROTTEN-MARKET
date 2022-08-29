using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    int randomNum;
    //private Vector3 spawnPos;
    int num = 0;

    
    
    public void SpawnCoin(GameObject coin, Vector3 spawnPos)
    {
        //spawnPos = transform.position;
        StartCoroutine(CreateCoins(GenerateRandomNum(num), coin, spawnPos));
    }

    IEnumerator CreateCoins(int number, GameObject coin, Vector3 spawnPos)
    {
        //death anim
        for(int i = 0; i < number; i++)
        {
            GameObject coins = Instantiate(coin, spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(0.25f);
        }
    }

    int GenerateRandomNum(int number)
    {
        randomNum = Random.Range(0, 100);

        if(randomNum >= 0 && randomNum <= 40)
        {
            randomNum = 1;
        }
        else if(randomNum > 40 && randomNum <= 80)
        {
            randomNum = 2;
        }
        else if(randomNum > 80 && randomNum <= 100)
        {
            randomNum = 3;
        }
        
        number = randomNum;
        return number;
    }
}
