using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "EnemyData")]
public class EnemyDataScript : ScriptableObject
{
    public float Health;
    public int WeaponDamage;
    public float RechargeTime;

}
