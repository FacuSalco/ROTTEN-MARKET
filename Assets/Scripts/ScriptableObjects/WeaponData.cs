using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "WeaponData")]
public class WeaponData : ScriptableObject
{
    public float weaponDamage, weaponRechangeTime, weaponCritChance;
    public bool hasBeenGrabed;
}
