using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public PlayerData Data;
    public int[] timesPressed = new int[5];
    public TMP_Text[] precios = new TMP_Text[5];
    public Text txtCoins;
    int myCoins;
    public GameObject canvas;
    public Image[] healthUpgrade = new Image[3];
    public Image[] speedUpgrade = new Image[3];
    public Image swordUpgrade;
    public Image[] jumpForceUpgrade = new Image[3];
    public Image[] damageUpgrade = new Image[3];

    // Start is called before the first frame update
    void Start()
    {
        timesPressed = Data.timesUpgraded;
    }

    // Update is called once per frame
    void Update()
    {
        myCoins = Data.cantMonedas;
        txtCoins.text = myCoins.ToString();

        //HACER PARA QUE ESTE BIEN EL PRECIO, POR AHORA SOLO ESTA CUANDO ESTA AL MAXIMO

        //UPDATE DEL HEALTH
        for (int i = 0; i < timesPressed[0]; i++)
        {
            healthUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[0] == 3)
            {
                precios[0].text = "MAX";
            }
        }

        //UPDATE DEL SPEED
        for (int i = 0; i < timesPressed[2]; i++)
        {
            speedUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[2] == 3)
            {
                precios[2].text = "MAX";
            }
        }

        //UPDATE DEL FORCE JUMP
        for (int i = 0; i < timesPressed[3]; i++)
        {
            jumpForceUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[3] == 3)
            {
                precios[3].text = "MAX";
            }
        }
    }

    public void UpgradeHealth ()
    {
        int precio = int.Parse(precios[0].text);
        //Debug.Log(precio);

        if (timesPressed[0] <=3 && myCoins >= precio)
        {
            timesPressed[0]++;
            Data.playerMaxHealth += 25;
            Data.playerHealth += 10;
            Data.cantMonedas -= precio;

            if (timesPressed[0] != 3)
            {
                precios[0].text = (precio * 2).ToString();
            }
        }

    }

    public void UpgradeDamage()
    {

        if (timesPressed[1] <= 3)
        {
            timesPressed[1]++;
            Data.playerDamage += 20;            
        }
    }

    public void UpgradeSpeed()
    {
        int precio = int.Parse(precios[2].text);
        

        if (timesPressed[2] <= 3 && myCoins >= precio)
        {
            timesPressed[2]++;
            Data.playerSpeed += 1.5f;
            Data.cantMonedas -= precio;

            if (timesPressed[2] != 3)
            {
                precios[2].text = (precio * 2).ToString();
            }
        }
    }

    public void UpgradeJumpForce()
    {
        int precio = int.Parse(precios[3].text);

        if (timesPressed[3] <= 3 && myCoins >= precio)
        {
            timesPressed[3]++;
            Data.playerJumpForce += 2;
            Data.cantMonedas -= precio;

            if (timesPressed[3] != 3)
            {
                precios[3].text = (precio * 2).ToString();
            }
        }
    }

    public void UpgradeSword()
    {
        if (timesPressed[4] <= 1)
        {
            timesPressed[4]++;
            Data.hasSword = true;
        }
    }

}
