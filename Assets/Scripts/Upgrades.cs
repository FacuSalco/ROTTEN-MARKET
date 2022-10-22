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
    public Image x2CoinsUpgrade;
    public PlayerData Data;
    public int[] timesPressed = new int[4];
    public TMP_Text[] precios = new TMP_Text[6];
    int[] precio = new int[6];
    public Image[] healthUpgrade = new Image[3];
    public Image[] speedUpgrade = new Image[3];
    public Image[] jumpForceUpgrade = new Image[3];
    public Image[] damageUpgrade = new Image[3];
    SFXManager SFX;


    // Start is called before the first frame update
    void Start()
    {
        timesPressed = Data.timesUpgraded;
        
        for (int i = 0; i < precios.Length; i++)
        {
            precios[i].text = precioMejora.ToString();
            precio[i] = int.Parse(precios[i].text);

            if (i == 4) //ESPADA
            {
                precios[i].text = (precioMejora*3).ToString();
                precio[i] = int.Parse(precios[i].text);
            }

            if (i == 5) //MONEDAS
            {
                precios[i].text = (precioMejora * 7).ToString();
                precio[i] = int.Parse(precios[i].text);
            }
        }

        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();

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

        //UPDATE DEL X2 COINS
        
        if (Data.x2Coins == true)
        {
            x2CoinsUpgrade.GetComponent<Image>().color = Color.green;
            precios[5].text = "MAX";
        }


    }

    public void UpgradeHealth()
    {
        
        if (myCoins < precio[0] || timesPressed[0] >= 3)
        {
            SFX.PlayClickErrorSound();
            return;
        }
        
        if (timesPressed[0] < 3 && myCoins >= precio[0])
        {
            SFX.PlayCoinSound();
            timesPressed[0]++;
            Data.playerMaxHealth += 25;
            Data.playerHealth += 10;
            Data.cantMonedas -= precio[0];
        }
        
    }

    public void UpgradeDamage()
    {
        if (myCoins < precio[1] || timesPressed[1] >= 3)
        {
            SFX.PlayClickErrorSound();
            return;
        }

        if (timesPressed[1] < 3 && myCoins >= precio[1])
        {
            SFX.PlayCoinSound();
            timesPressed[1]++;
            Data.playerDamage += 20;
            Data.cantMonedas -= precio[1];
        }

    }

    public void UpgradeSpeed()
    {
        if (myCoins < precio[2] || timesPressed[2] >= 3)
        {
            SFX.PlayClickErrorSound();
            return;
        }

        if (timesPressed[2] < 3 && myCoins >= precio[2])
        {
            SFX.PlayCoinSound();
            timesPressed[2]++;
            Data.playerSpeed += 1.5f;
            Data.cantMonedas -= precio[2];
        }
    }

    public void UpgradeJumpForce()
    {
        if (myCoins < precio[3] || timesPressed[3] >= 3)
        {
            SFX.PlayClickErrorSound();
            return;
        }

        if (timesPressed[3] < 3 && myCoins >= precio[3])
        {
            SFX.PlayCoinSound();
            timesPressed[3]++;
            Data.playerJumpForce += 2.5f;
            Data.cantMonedas -= precio[3];
        }
    }

    public void UpgradeSword()
    {
        if (myCoins < precio[4] || Data.hasSword == true)
        {
            SFX.PlayClickErrorSound();
            return;
        }

        if (Data.hasSword == false && myCoins >= precio[4])
        {
            SFX.PlayCoinSound();
            Data.hasSword = true;
            Data.cantMonedas -= precio[4];
        }
    }

    public void UpgradeCoinsX2()
    {
        if (myCoins < precio[5] || Data.x2Coins == true)
        {
            SFX.PlayClickErrorSound();
            return;
        }

        if (Data.x2Coins == false && myCoins >= precio[5])
        {
            SFX.PlayCoinSound();
            Data.x2Coins = true;
            Data.cantMonedas -= precio[5];
        }
    }

}
