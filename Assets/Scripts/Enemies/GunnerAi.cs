using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class GunnerAi : MonoBehaviour
{
   
    //player detect
    public float rangoDeAlerta, rangoDeAlerta2, correrDelJugador, fireRange;
    public LayerMask capaDelJugador;
    bool estarAlerta, estarAlerta2, jugadorCerca, notWalk;
    public Transform runDir;
    private Transform Player;
    public float enemySpeed, enemySpeed2;
    bool runAway = false;
    EnemyNavMeshController enemyNav;
    private Animator enemyAnimator;

    //attack
    public float time = 2;

    //turret
    public GameObject bulletPrefab;
    public float rateOfFire = 1f;
    float fireRateDelta;
    public Transform turretPivotRight, turretPivotLeft;
    private bool isReadyToShoot = true;
    
    //raycast
    public Transform shadowBody;
    [SerializeField] private bool playerSeen = false;
    [SerializeField] private float rayDistance;
    RaycastHit hit;
    //navigation movement
    //EnemyNavMeshController enemyNav;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;
        enemyNav = gameObject.GetComponent<EnemyNavMeshController>();
    }

    // Update is called once per frame
    void Update()
    {
        //seteando las esferas

        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        jugadorCerca = Physics.CheckSphere(transform.position, correrDelJugador, capaDelJugador);

        notWalk = Physics.CheckSphere(transform.position, fireRange, capaDelJugador);

        //camina hacia el jugador sin disparar


        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);

        shadowBody.transform.LookAt(Player);

        if (hit.collider && hit.collider.gameObject.name == "Player")
        {
            playerSeen = true;
            enemyAnimator.SetBool("playerSeen", true);
        }

        if(playerSeen == true)
        {
            if (estarAlerta2 == true && estarAlerta == false && jugadorCerca == false && runAway == false && notWalk == false)
            {

                Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
                transform.LookAt(playerPos);
                transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);

            }

            if (estarAlerta == true)
            {

                Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);

                //Mira al jugador si esta en el área
                if (jugadorCerca == false)
                {

                    transform.LookAt(playerPos);

                }
                if (notWalk == false)
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);
                }
                //turret shot

                if (isReadyToShoot)
                {

                    ShootStart();

                }



            }
            else
            {
                playerSeen = false;
                enemyAnimator.SetBool("playerSeen", false);
            }
        }

 
   
    }

    public void FireRight()
    {
        GameObject clon;

        clon = Instantiate(bulletPrefab, turretPivotRight.transform.position, transform.rotation);
        Destroy(clon, 6);
    }

    public void FireLeft()
    {
        GameObject clon;

        clon = Instantiate(bulletPrefab, turretPivotLeft.transform.position, transform.rotation);
        Destroy(clon, 6);
    }

    IEnumerator ShootStart()
    {
        isReadyToShoot = false;
        enemyAnimator.SetBool("canShoot", true);

        yield return new WaitForSeconds(4f);

        enemyAnimator.SetBool("canShoot", false);
        isReadyToShoot = true;
    }

    //stop all coroutines

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta2);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, correrDelJugador);

        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, fireRange);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(shadowBody.transform.position, shadowBody.transform.forward * rayDistance);
    }
}
