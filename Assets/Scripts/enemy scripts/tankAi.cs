using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankAi : MonoBehaviour
{
    public float rangoDeAlerta, rangoDeAlerta2;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    bool estarAlerta2;
    private Transform Player;
    public float enemySpeed;
    public float enemySpeed2;
    public float rangoDeAtaque;
    bool prockAttack;
    bool isAttacking = false;

    //raycast
    public Transform shadowBody;
    [SerializeField] private bool playerSeen = false;
    [SerializeField] private float rayDistance;
    RaycastHit hit;

    // navigation 
    EnemyNavMeshController enemyNav;

   

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        enemyNav = gameObject.GetComponent<EnemyNavMeshController>();
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);
        //


        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);

        shadowBody.transform.LookAt(Player);

        if (hit.collider && hit.collider.gameObject.name == "Player")
        {
            playerSeen = true;
        }

        if (playerSeen == true)
        {
            if (estarAlerta == true && isAttacking == false)
            {
                enemyNav.navRun();
                //run anim
            }

            if (estarAlerta2 == true && estarAlerta == false)
            {
                enemyNav.navWalk();

                //walk anim
            }
        }

        if (estarAlerta == false && estarAlerta2 == false)
        {
            playerSeen = false;
            //sleep anim
        }

        if(prockAttack == true && isAttacking == false)
        {
            //attack anim
            isAttacking = true;
            StartCoroutine(attack());
        }

    }

    IEnumerator attack()
    {

        gameObject.GetComponent<Animator>().Play("tankAttack");
        yield return new WaitForSeconds(2.8f);
        gameObject.GetComponent<Animator>().Play("New State");
        isAttacking = false;

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
