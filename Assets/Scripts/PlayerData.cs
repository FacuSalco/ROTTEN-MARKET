using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    public int cantMonedas;
    public float playerHealth;
    public float playerMaxHealth;
    public float playerDamage;
    public float playerSpeed;
    public float playerJumpForce;
    public int[] timesUpgraded = new int[5];
    public bool hasSword;
    public bool keepCoins;
    public bool resetAlways;
    public bool resetNextGame;
    public bool immortal;

    public void addCoins(int coins)
    {
        cantMonedas += coins;
    }

}
