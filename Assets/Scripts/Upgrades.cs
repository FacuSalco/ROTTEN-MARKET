using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public int precioMejora = 3;
    public Text txtCoins;
    int myCoins;
    public Image swordUpgrade;
    public PlayerData Data;
    public int[] timesPressed = new int[5];
    public TMP_Text[] precios = new TMP_Text[5];
    public Image[] healthUpgrade = new Image[3];
    public Image[] speedUpgrade = new Image[3];
    public Image[] jumpForceUpgrade = new Image[3];
    public Image[] damageUpgrade = new Image[3];


    // Start is called before the first frame update
    void Start()
    {
        timesPressed = Data.timesUpgraded;
        
        for (int i = 0; i < precios.Length; i++)
        {
            precios[i].text = precioMejora.ToString();

            if (i == 4)
            {
                precios[i].text = (precioMejora*3).ToString();
            }
        }

        

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
                healthUpgrade[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                precios[0].text = (precioMejora * (timesPressed[0] + 1)).ToString();
            }

        }

        //UPDATE DEL DAMAGE
        for (int i = 0; i < timesPressed[1]; i++)
        {
            damageUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[1] == 3)
            {
                precios[1].text = "MAX";
                damageUpgrade[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                precios[1].text = (precioMejora * (timesPressed[1] + 1)).ToString();
            }
        }


        //UPDATE DEL SPEED
        for (int i = 0; i < timesPressed[2]; i++)
        {
            speedUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[2] == 3)
            {
                precios[2].text = "MAX";
                speedUpgrade[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                precios[2].text = (precioMejora * (timesPressed[2] + 1)).ToString();
            }
        }

        //UPDATE DEL FORCE JUMP
        for (int i = 0; i < timesPressed[3]; i++)
        {
            jumpForceUpgrade[i].GetComponent<Image>().color = Color.white;

            if (timesPressed[3] == 3)
            {
                precios[3].text = "MAX";
                jumpForceUpgrade[i].GetComponent<Image>().color = Color.green;
            }
            else
            {
                precios[3].text = (precioMejora * (timesPressed[3] + 1)).ToString();
            }

        }
        
        //UPDATE DE LA SWORD
        if (Data.hasSword == true)
        {
            swordUpgrade.GetComponent<Image>().color = Color.green;
            precios[4].text = "MAX";
        }

    }

    public void UpgradeHealth ()
    {
        int precio = int.Parse(precios[0].text);

        if (timesPressed[0] < 3 && myCoins >= precio)
        {
            timesPressed[0]++;
            Data.playerMaxHealth += 25;
            Data.playerHealth += 10;
            Data.cantMonedas -= precio;
        }

    }

    public void UpgradeDamage()
    {
        int precio = int.Parse(precios[1].text);

        if (timesPressed[1] < 3 && myCoins >= precio)
        {
            timesPressed[1]++;
            Data.playerDamage += 20;
            Data.cantMonedas -= precio;
        }
    }

    public void UpgradeSpeed()
    {
        int precio = int.Parse(precios[2].text);       

        if (timesPressed[2] < 3 && myCoins >= precio)
        {
            timesPressed[2]++;
            Data.playerSpeed += 1.5f;
            Data.cantMonedas -= precio;
        }
    }

    public void UpgradeJumpForce()
    {
        int precio = int.Parse(precios[3].text);

        if (timesPressed[3] < 3 && myCoins >= precio)
        {
            timesPressed[3]++;
            Data.playerJumpForce += 2;
            Data.cantMonedas -= precio;
        }
    }

    public void UpgradeSword()
    {
        int precio = int.Parse(precios[4].text);

        if (Data.hasSword == false && myCoins >= precio)
        {
            Data.hasSword = true;
            Data.cantMonedas -= precio;
        }
    }

}
