using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAi : MonoBehaviour
{

    //variables
    [Header("Dectección de Jugador")]

    public float rangoDeAlerta;
    public float rangoDeAlerta2;
    public float rangoDeAtaque;
    public LayerMask capaDelJugador;
    private bool estarAlerta, estarAlerta2, prockAttack;
    private Transform Player;
    //rutina
    [Header("Rutina de movimiento")]
    public bool CanWonder;
    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grado;

    //navMesh
    private NavMeshAgent agent;

    [Header("Atacar Jugador")]
    //raycast
    public Transform shadowBody;
    [SerializeField] private bool playerSeen = false; 
    [SerializeField] private float rayDistance;
    private RaycastHit hit;
    public GameObject Katana;
    //navigation movement
    private EnemyNavMeshController enemyNav;
    //animator
    private bool CanAttack = true;
    private bool awakeningComplete = false;
    private Animator enemyAnimator;



    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;

        agent = GetComponent<NavMeshAgent>();

        enemyNav = GetComponent<EnemyNavMeshController>();

        enemyAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //setting up checking spheres
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);

        //raycast setup
        

        Physics.Raycast(shadowBody.position, shadowBody.transform.forward, out hit, rayDistance);

        shadowBody.transform.LookAt(Player);

        //movement

        if(hit.collider && hit.collider.gameObject.name == "Player")
        {

            if (!awakeningComplete)
            {
                StartCoroutine(enemyAwakened());

                enemyAnimator.SetBool("hasAwaken", true);
            }

            if (awakeningComplete)
            {
                playerSeen = true;
            }

        }

        if(playerSeen == true)
        {
            if (estarAlerta == true && !prockAttack)
            {

                enemyNav.navRun();
                enemyAnimator.SetBool("isWalking", true);

                //run anim
            }

            if (estarAlerta2 == true && estarAlerta == false && !prockAttack)
            {
                enemyNav.navWalk();
                enemyAnimator.SetBool("isWalking", true);
                //walk anim
            }

            if (prockAttack)
            {
                if (CanAttack)
                {
                    StartCoroutine(Attacking());
                    //enemyAnimator.SetBool("canAttack", true);
                }

            }

            if (estarAlerta == false && estarAlerta2 == false)
            {
                playerSeen = false;
                enemyAnimator.SetBool("isWalking", false);
                awakeningComplete = false;
                enemyAnimator.SetBool("hasAwaken", false);
            }

        }

        if (estarAlerta == false && estarAlerta2 == false)
        {
            if (CanWonder)
            {
               ComportamientoEnemigo();
            }
        }
    }

    IEnumerator Attacking()
    {
        CanAttack = false;
        enemyAnimator.SetBool("canAttack", true);

        yield return new WaitForSeconds(1f);

        enemyAnimator.SetBool("canAttack", false);
        CanAttack = true;
    }

    IEnumerator enemyAwakened()
    {
        awakeningComplete = false;

        yield return new WaitForSeconds(3f);

        awakeningComplete = true;
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

    public void ActivateRightSword()
    {
        Collider KatanaCollider = Katana.GetComponent<Collider>();

        KatanaCollider.enabled = true;

    }

    public void DesactivateRightSword()
    {
        Collider KatanaCollider = Katana.GetComponent<Collider>();

        KatanaCollider.enabled = false;
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
