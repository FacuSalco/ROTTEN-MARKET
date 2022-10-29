using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    private int Damage = 5;
    public float projectileSpeed = 5f;
    public bulletScriptableObject TrailConfig;
    protected TrailRenderer Trail;
    protected Transform Target;
    private Transform Player;
    private HealthBar PlayerHealthBar;
    public EnemyData Data;
    

    private void Start()
    {
        PlayerHealthBar = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthBar>();
        Damage = 20;

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
    

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            PlayerHealthBar.makeDamage(Damage);
            Destroy(gameObject);
        }

    }
}
