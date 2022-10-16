using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    public int Damage = 5;
    public float projectileSpeed = 5f;
    public bulletScriptableObject TrailConfig;
    protected TrailRenderer Trail;
    protected Transform Target;
    private Transform Player;
    HealthBar Health;
    

    private void Start()
    {
        Health = GetComponent<HealthBar>();
    }

    private void Awake()
    {
        Trail = GetComponent<TrailRenderer>();
        ConfigureTrail();
    }

    void Update()
    {
        transform.Translate(transform.forward * projectileSpeed * Time.deltaTime);
    }

    private void ConfigureTrail()
    {
        if (Trail != null && TrailConfig != null)
        {
            TrailConfig.SetupTrail(Trail);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
            Health.makeDamage(Damage);
            Destroy(gameObject);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Health.makeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
