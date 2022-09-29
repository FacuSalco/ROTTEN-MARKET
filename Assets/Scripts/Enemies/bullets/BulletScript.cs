using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletScript : MonoBehaviour
{
    public float AutoDestroyTime = 5f;
    public float MoveSpeed = 2f;
    public int Damage = 5;
    public Rigidbody Rigidbody;
    public bulletScriptableObject TrailConfig;
    protected TrailRenderer Trail;
    protected Transform Target;
    [SerializeField]
    private Renderer Renderer;
    private GameObject Player;

    private bool IsDisabling = false;

    protected const string DISABLE_METHOD_NAME = "Disable";
    protected const string DO_DISABLE_METHOD_NAME = "DoDisable";

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(Player.transform);
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Trail = GetComponent<TrailRenderer>();
    }

    protected virtual void OnEnable()
    {
        if (Renderer != null)
        {
            Renderer.enabled = true;
        }

        IsDisabling = false;
        CancelInvoke(DISABLE_METHOD_NAME);
        ConfigureTrail();
        Invoke(DISABLE_METHOD_NAME, AutoDestroyTime);
    }

    private void ConfigureTrail()
    {
        if (Trail != null && TrailConfig != null)
        {
            TrailConfig.SetupTrail(Trail);
        }
    }

    public virtual void Spawn(Vector3 Forward, int Damage, Transform Target)
    {
        this.Damage = Damage;
        this.Target = Target;
        Rigidbody.AddForce(Forward * MoveSpeed, ForceMode.VelocityChange);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        
    }

    protected void Disable()
    {
        CancelInvoke(DISABLE_METHOD_NAME);
        CancelInvoke(DO_DISABLE_METHOD_NAME);
        Rigidbody.velocity = Vector3.zero;
        if (Renderer != null)
        {
            Renderer.enabled = false;
        }


        if (Trail != null && TrailConfig != null)
        {
            IsDisabling = true;
            Invoke(DO_DISABLE_METHOD_NAME, TrailConfig.Time);
        }
        else
        {
            DoDisable();
        }
    }

    protected void DoDisable()
    {
        if (Trail != null && TrailConfig != null)
        {
            Trail.Clear();
        }

        gameObject.SetActive(false);
    }
}
