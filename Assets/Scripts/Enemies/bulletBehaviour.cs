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

    private void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        //transform.LookAt(Player);
    }

    private void Awake()
    {
        Trail = GetComponent<TrailRenderer>();
        ConfigureTrail();
    }

    void Update()
    {
        transform.Translate(transform.up * projectileSpeed * Time.deltaTime);
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
        if (col.gameObject.name == "wall")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter()
    {
        
    }
}
