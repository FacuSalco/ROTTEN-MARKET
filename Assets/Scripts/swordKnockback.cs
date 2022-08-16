using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordKnockback : MonoBehaviour
{
    [SerializeField] private float knockbackStrength;

    void Start()
    {
        knockbackStrength = swordScript.swordKnockback;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Rigidbody rb = col.collider.GetComponent<Rigidbody>();

            if(rb != null)
            {
                Vector3 direction = col.transform.position - transform.position;
                direction.y = 0;

                rb.AddForce(direction.normalized * knockbackStrength, ForceMode.Impulse);
            }
        }
    }
}
