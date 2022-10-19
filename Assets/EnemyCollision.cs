using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerStats PlayerData;
    private EnemyHealthBar HealthBarController;

    private bool doHitOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        HealthBarController = GetComponent<EnemyHealthBar>();

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "handHitbox")
        {
            if (doHitOnce)
            {
                Debug.Log("hit");

                float damage = PlayerData.PunchData.weaponDamage;
                HealthBarController.dealDamage(damage);
                StartCoroutine(DoDamageOnce());
            }

        }
    }

    IEnumerator DoDamageOnce()
    {
        doHitOnce = false;

        yield return new WaitForSeconds(0.5f);

        doHitOnce = true;
    }

}
