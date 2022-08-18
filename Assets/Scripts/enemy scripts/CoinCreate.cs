using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCreate : MonoBehaviour
{
    public GameObject coinPrefab;
    int randomNum;
    private Vector3 spawnPos;
    int num = 0;

    
    
    public void SpawnCoin()
    {
        spawnPos = transform.position;
        StartCoroutine(CreateCoins(GenerateRandomNum(num)));
        Debug.Log(GenerateRandomNum(num));
    }

    IEnumerator CreateCoins(int number)
    {
        //death anim
        for(int i = 0; i < number; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = spawnPos;

            yield return new WaitForSeconds(0.15f);
        }
    }

    int GenerateRandomNum(int number)
    {
        randomNum = Random.Range(0, 100);

        if(randomNum >= 0 && randomNum <= 40)
        {
            randomNum = 1;
        }
        else if(randomNum >= 40 && randomNum <= 80)
        {
            randomNum = 2;
        }
        else if(randomNum <= 80 && randomNum <= 100)
        {
            randomNum = 3;
        }

        number = randomNum;
        return number;
    }
}
