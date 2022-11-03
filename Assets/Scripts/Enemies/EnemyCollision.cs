using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private PlayerStats PlayerData;
    private EnemyHealthBar HealthBarController;
    SFXManager SFX;

    private bool doHitOnce = true;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        HealthBarController = GetComponent<EnemyHealthBar>();
        SFX = GameObject.Find("[SFX-MANAGER]").GetComponent<SFXManager>();

    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "handHitbox")
        {
            if (doHitOnce)
            {
                Debug.Log("hit");

                DamageEnemyPunch();
                KnockBackBody();
            }

        }
    }

    private void DamageEnemyPunch()
    {
        if (doHitOnce)
        {
            float damage = PlayerData.PunchData.weaponDamage;
            HealthBarController.dealDamage(damage);
            StartCoroutine(DoDamageOnce());
            SFX.PlayPunchSound();
        }
    }

    private void KnockBackBody()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(-transform.forward * 15f, ForceMode.Impulse);

    }

    IEnumerator DoDamageOnce()
    {
        doHitOnce = false;

        yield return new WaitForSeconds(0.5f);

        doHitOnce = true;
    }

}
