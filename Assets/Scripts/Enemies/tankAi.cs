using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankAi : MonoBehaviour
{
    public float rangoDeAlerta, rangoDeAlerta2, rangoDeAtaque;
    private bool estarAlerta, estarAlerta2, prockAttack;
    public LayerMask capaDelJugador;
    private Transform Player;

    public bool isAttacking = false;

    //raycast
    public Transform shadowBody;
    [SerializeField] private bool playerSeen = false;
    private float rayDistance;
    RaycastHit hit;

    // navigation 
    EnemyNavMeshController enemyNav;
    private Animator EnemyAnimator;
    public GameObject Weapon;

   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        enemyNav = gameObject.GetComponent<EnemyNavMeshController>();

        EnemyAnimator = GetComponent<Animator>();

        rayDistance = rangoDeAlerta2;
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);


        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);

        shadowBody.transform.LookAt(Player);

        if (hit.collider && hit.collider.gameObject.name == "Player")
        {
            playerSeen = true;
        }

        if (playerSeen == true)
        {

            if (estarAlerta2)
            {
                if (estarAlerta && !isAttacking)
                {
                    enemyNav.navRun();
                    EnemyAnimator.SetBool("IsWalking", true);

                }
                if (estarAlerta2 && !isAttacking)
                {
                    enemyNav.navWalk();
                    EnemyAnimator.SetBool("IsWalking", true);

                }
                //walk anim
                EnemyAnimator.SetBool("IsWalking", true);


            }
        }

        if (!estarAlerta && !estarAlerta2)
        {
            playerSeen = false;
            EnemyAnimator.SetBool("IsWalking", false);
            //sleep anim
        }

        if( prockAttack && !isAttacking )
        {
            //attack anim

            StartCoroutine(attack());

        }

        if (isAttacking)
        {
            EnemyAnimator.SetBool("CanAttack", true);
            EnemyAnimator.SetBool("IsWalking", false);
        }
        else
        {
            EnemyAnimator.SetBool("CanAttack", false);
        }

    }

    IEnumerator attack()
    {
        isAttacking = true;
        yield return new WaitForSeconds(2f);
        isAttacking = false;

    }

    public void ActivateWeapon()
    {
        Weapon.SetActive(true);
    }

    public void DeActivateWeapon()
    {
        Weapon.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta2);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);

        Gizmos.color = Color.red;
        Gizmos.DrawRay(shadowBody.transform.position, shadowBody.transform.forward * rayDistance);
    }

}
