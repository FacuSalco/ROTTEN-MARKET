using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnowBallManager : MonoBehaviour
{
    public int SBObjetivo ,cantSnowBalls;
    public GameObject SFWall;

    [Header("UI")]
    public Text cantSBtxt;
    public TMP_Text cantSBtxtTMP;

    // Start is called before the first frame update
    void Start()
    {
        SBObjetivo = GameObject.FindGameObjectsWithTag("SnowBall").Length;
        cantSBtxtTMP.text = "NECESITAS " + SBObjetivo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        cantSBtxt.text = cantSnowBalls.ToString();

        if (cantSnowBalls >= SBObjetivo)
        {
            SFWall.SetActive(false);
        }

    }

    public void CollectSnowBall()
    {
        cantSnowBalls++;        
    }

}