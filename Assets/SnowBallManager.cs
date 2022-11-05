using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnowBallManager : MonoBehaviour
{
    public int cantSnowBalls;
    public Text cantSBtxt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cantSBtxt.text = cantSnowBalls.ToString();
    }

    public void CollectSnowBall()
    {
        cantSnowBalls++;
        
    }

}
