using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Upgrades : MonoBehaviour
{
    public PlayerData Data;
    int[] timesPressed = new int[5];
    public TMP_Text[] precios = new TMP_Text[5];
    public Text txtCoins;
    int myCoins;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        myCoins = Data.cantMonedas;
        txtCoins.text = myCoins.ToString(); //CIRO PUEDE SER QUE TENGAS QUE COMENTAR ESTA LINEA
    }

    public void UpgradeHealth ()
    {
        int precio = int.Parse(precios[0].text);
        //Debug.Log(precio);
        
        timesPressed[0]++;
        
        if (timesPressed[0] <=3 && myCoins >= precio)
        {
            Data.playerMaxHealth += 25;
            Data.playerHealth += 10;
            Data.cantMonedas -= precio;
            if (timesPressed[0] == 3)
            {
                precios[0].text = "MAX";
            }
            else
            {
                precios[0].text = (precio * 2).ToString();
            }
        }

    }
    
    //HACER PARA VERIFICAR SI YA FUERON MEJORADAS Y CUANTAS VECES

    //AGREGAR LAS MISMAS COSAS QUE TIENE LA DE ARRIBA A TODAS LAS OTRAS (MONEDAS Y TODO LO QUE TENGA QUE VER CON ESO) Y HACERLAS FUNCIONAR

    public void UpgradeDamage()
    {
        timesPressed[1]++;

        if (timesPressed[1] <= 3)
        {
            Data.playerDamage += 20;            
        }
    }

    public void UpgradeSpeed()
    {
        int precio = int.Parse(precios[2].text);
        
        timesPressed[2]++;

        if (timesPressed[2] <= 3 && myCoins >= precio)
        {
            Data.playerSpeed += 1.5f;
            Data.cantMonedas -= precio;
            if (timesPressed[2] == 3)
            {
                precios[2].text = "MAX";
            }
            else
            {
                precios[2].text = (precio * 2).ToString();
            }
        }
    }

    public void UpgradeJumpForce()
    {
        timesPressed[3]++;

        if (timesPressed[3] <= 3)
        {
            Data.playerJumpForce += 2;            
        }
    }

    public void UpgradeSword()
    {
        timesPressed[4]++;
        if (timesPressed[4] <= 1)
        {
            Data.hasSword = true;
        }
    }

}
