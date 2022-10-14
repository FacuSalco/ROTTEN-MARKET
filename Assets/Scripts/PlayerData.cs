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
    public bool hasSword;
}
