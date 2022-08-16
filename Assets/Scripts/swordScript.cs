using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject Sword;

    public static float swordDamage, swordSpeed, swordKnockback;
    
    void Start()
    {
        swordDamage = 10f;
        swordSpeed = 1f;
        swordKnockback = 10f;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCoroutine(SwordSwing());
        }
    }

    IEnumerator SwordSwing()
    {
        Sword.GetComponent<Animator>().Play("SwordSwing2");
        yield return new WaitForSeconds(swordSpeed);
        Sword.GetComponent<Animator>().Play("New State");
    }
}
