using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordScript : MonoBehaviour
{
    public GameObject Sword;

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
        yield return new WaitForSeconds(1.0f);
        Sword.GetComponent<Animator>().Play("New State");
    }
}
