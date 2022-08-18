using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAi : MonoBehaviour
{

    //variables
    public float rangoDeAlerta, rangoDeAlerta2, rangoDeAtaque;
    public LayerMask capaDelJugador;
    bool estarAlerta, estarAlerta2;
    bool prockAttack;
    private Transform Player;

    //rutina

    int rutina;
    float cronometro;
    //public Animation ani;
    Quaternion angulo;
    float grado;

    //navMesh
    public float walkSpeed;
    public float runSpeed;
    private NavMeshAgent agent;

    //raycast
    public Transform shadowBody;
    [SerializeField] private bool playerSeen = false; 
    [SerializeField] private float rayDistance;

    //navigation movement
    EnemyNavMeshController enemyNav;
    


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        enemyNav = GetComponent<EnemyNavMeshController>();


    }

    // Update is called once per frame
    void Update()
    {
        //setting up checking spheres
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);

        //raycast setup
        RaycastHit hit;

        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);

        shadowBody.transform.LookAt(Player);

        if(hit.collider.gameObject.name == "Player")
        {
            playerSeen = true;
        }

        if(playerSeen == true)
        {
            if (estarAlerta == true)
            {

               enemyNav.navRun();

                //run anim
            }

            if (estarAlerta2 == true && estarAlerta == false)
            {
                enemyNav.navWalk();
                //walk anim
            }

            if(estarAlerta == false && estarAlerta2 == false)
            {
                playerSeen = false;
            }

        }


        if (estarAlerta == false && estarAlerta2 == false)
        {
            ComportamientoEnemigo();
        }

       
    }
    
    public void ComportamientoEnemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = 0;
        }

        switch (rutina)
        {
            case 0:
                break;

            case 1:
                grado = Random.Range(0, 360);
                angulo = Quaternion.Euler(0, grado, 0);
                rutina++;

                break;

            case 2:
                transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                break;
        }


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
