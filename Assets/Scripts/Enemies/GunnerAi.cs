using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;  

public class GunnerAi : MonoBehaviour
{
   
    //player detect
    public float attackingRange, walkingRange, correrDelJugador, fireRange;
    public LayerMask capaDelJugador;
    private bool attackingRangeBool, walkingRangeBool, jugadorCerca, notWalk;
    private Transform Player;
    public float enemySpeed, enemySpeed2;
    private Animator enemyAnimator;

    //turret
    public GameObject bulletPrefab;
    public Transform turretPivotRight, turretPivotLeft;
    private bool isReadyToShoot = true;
    
    //raycast
    public Transform shadowBody;
    private bool playerSeen = false;
    private float rayDistance;
    RaycastHit hit;
    //navigation movement
    //EnemyNavMeshController enemyNav;

    void Start()
    {
        enemyAnimator = GetComponent<Animator>();
        Player = GameObject.FindWithTag("Player").transform;

        rayDistance = walkingRange;
    }

    // Update is called once per frame
    void Update()
    {
        //seteando las esferas
        attackingRangeBool = Physics.CheckSphere(transform.position, attackingRange, capaDelJugador);
        walkingRangeBool = Physics.CheckSphere(transform.position, walkingRange, capaDelJugador);
        jugadorCerca = Physics.CheckSphere(transform.position, correrDelJugador, capaDelJugador);
        notWalk = Physics.CheckSphere(transform.position, fireRange, capaDelJugador);

        //Se fija si el jugador esta en el rango y devuelve true/false
        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);
        shadowBody.LookAt(Player);
        if (hit.collider && hit.collider.gameObject.name == "Player")
        {
            playerSeen = true;
            enemyAnimator.SetBool("PlayerSeen", true);
        }
        else
        {
            playerSeen = false;
            enemyAnimator.SetBool("PlayerSeen", false);
        }

        //activa al enemigo
        if(playerSeen == true)
        {
            if (walkingRangeBool && !attackingRangeBool)
            {
                Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
                transform.LookAt(playerPos);
                transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);
            }

            if (attackingRangeBool)
            {
                //definimos la posición del jugador con el eje y en 0
                Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);

                //Mira al jugador si esta en el área
                if (!jugadorCerca)
                {
                    transform.LookAt(playerPos);

                    if (isReadyToShoot)
                    {
                        isReadyToShoot = false;

                        StartCoroutine(ShootAnim());

                    }

                }
                if (!notWalk)
                {
                    transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);
                }
                //turret shot
            }
   
        }  
    }

    IEnumerator ShootAnim()
    {
        enemyAnimator.SetBool("CanShoot", true);

        yield return new WaitForSeconds(3f);

        isReadyToShoot = true;
        enemyAnimator.SetBool("CanShoot", false);
    }

    public void FireRight()
    {
        GameObject clon;

        clon = Instantiate(bulletPrefab, turretPivotRight.transform.position, turretPivotRight.transform.rotation);
        Destroy(clon, 6);
    }

    public void FireLeft()
    {
        GameObject clon;

        clon = Instantiate(bulletPrefab, turretPivotLeft.transform.position, turretPivotRight.transform.rotation);
        Destroy(clon, 6);
    }


    //stop all coroutines

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackingRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkingRange);

        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, correrDelJugador);

        Gizmos.color = Color.grey;
        Gizmos.DrawWireSphere(transform.position, fireRange);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(shadowBody.transform.position, shadowBody.transform.forward * rayDistance);
    }
}
