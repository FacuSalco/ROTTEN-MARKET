using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class GunnerAi : MonoBehaviour
{
   
    //player detect
    public float rangoDeAlerta, rangoDeAlerta2, correrDelJugador;
    public LayerMask capaDelJugador;
    bool estarAlerta, estarAlerta2, jugadorCerca;
    public Transform Player, minusPlayer;
    public float enemySpeed, enemySpeed2;
    bool OnAwake = false;
    public float cronometro;
    public float runAwayRate;
    float runAwayDelta;
    bool runAway = false;

    //attack
    public float time = 2;
    bool attackCooldown = false;

    //turret
    public GameObject bulletPrefab;
    public float rateOfFire = 1f;
    float fireRateDelta;
    public Transform turretPivot;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        jugadorCerca = Physics.CheckSphere(transform.position, correrDelJugador, capaDelJugador);

        //camina hacia el jugador sin disparar

        if (estarAlerta2 == true && estarAlerta == false && jugadorCerca == false && runAway == false)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);
        }

        if (estarAlerta == true && jugadorCerca == false && runAway == false)
        {

            //Mira al jugador si esta en el área

            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);

            //turret shot

            fireRateDelta -= Time.deltaTime;
            if (fireRateDelta <= 0)
            {
                Fire();
                fireRateDelta = rateOfFire;
            }

        }

        if (jugadorCerca == true)
        {
            Vector3 playerPos = new Vector3(minusPlayer.position.x, transform.position.y, minusPlayer.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);

        }
    }

    public void Fire()
    {
        GameObject clon;
        clon = Instantiate(bulletPrefab, turretPivot.transform.position, transform.rotation);
        Destroy(clon, 6);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta2);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, correrDelJugador);

    }
}
