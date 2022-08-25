using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstBossBehaviourAI : MonoBehaviour
{
    //setUp
    private Transform Player;
    public LayerMask capaDelJugador;

    //rangos
    public float outerLongRange, innerLongRange, meeleRange;
    private bool outerRangeBool, innerRangeBool, meeleRangeBool;

    //fases del enemigo

    private bool isSpawning = true;
    private bool firstFase = false;
    private bool secondFase = false;
    private bool isDying = false;

    //anim
    private bool isAnimating = false;
    private bool isIdling = false;
    private bool isAtacking = false;

    //Turret
    public Transform shootingPivot;
    public GameObject bulletPrefab;
    public GameObject granadePrefab;
    public float shootingRateOfAttack;
    private float shootingRateOfAttackDelta;
    public float granadeRateOfAttack;
    private float granadeRateOfAttackDelta;

    //spawner
    [SerializeField]HeaderAttribute SpawnerSett;
    public GameObject childPrefab;
    public float spawningRate;
    private float spawningRateDelta;

    //rutina
    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grado;

    //escape

    //Vida

    private EnemyHealthBar healthBarController;
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarController = GetComponent<EnemyHealthBar>();

        StartCoroutine(spawnRoutine());


        shootingRateOfAttackDelta = shootingRateOfAttack;
        granadeRateOfAttackDelta = granadeRateOfAttack;
    }

    // Update is called once per frame
    void Update()
    {
        //seteo de los rangos
        outerRangeBool = Physics.CheckSphere(transform.position, outerLongRange, capaDelJugador);
        innerRangeBool = Physics.CheckSphere(transform.position, innerLongRange, capaDelJugador);
        meeleRangeBool = Physics.CheckSphere(transform.position, meeleRange, capaDelJugador);

        //chequeo de vida para otorgar una fase
        health = healthBarController.currentHealth;

        if(isSpawning == false)
        {

            if (health >= health / 2)
            {
                firstFase = true;
            }
            else if (health <= health / 2)
            {
                firstFase = false;
                secondFase = true;
            }
            else
            {
                firstFase = false;
                secondFase = false;
                isDying = true;
            }

        }

        //crequea si esta haciendo alguna animacion
        if(isSpawning || isIdling || isAtacking)
        {
            isAnimating = true;
        }
        else
        {
            isAnimating = false;
        }

        //primera fase
        if (firstFase)
        {
            if (outerRangeBool && !innerRangeBool)
            {
                if (!isAnimating)
                {
                    bossFaseOneBehaviour();
                }

                //spawningChildren
                spawningRateDelta -= Time.deltaTime;
                if (spawningRateDelta < 0)
                {
                    StartCoroutine(spawningAttack());
                    spawningRateDelta = spawningRate;
                }

                //bullet-shooting
                shootingRateOfAttackDelta -= Time.timeScale;
                if(shootingRateOfAttack < 0)
                {
                    StartCoroutine(bulletShootAttack());
                    shootingRateOfAttackDelta = shootingRateOfAttack;
                }
                //granade-spawner
                granadeRateOfAttackDelta -= Time.timeScale;
                if (granadeRateOfAttack < 0)
                {
                    StartCoroutine(granadeShootAttack());
                    granadeRateOfAttackDelta = granadeRateOfAttack; 
                }

            } else if (innerRangeBool)
            {



            }
            else
            {
                isIdling = true;
            }


        }

        if (secondFase)
        {

        }
        

    }

    //ataques

    IEnumerator bulletShootAttack()
    {
        isAtacking = true;
        gameObject.GetComponent<Animator>().Play("New State");

        GameObject bulletClon;
        bulletClon = Instantiate(bulletPrefab, shootingPivot.transform.position, Quaternion.identity);
        Destroy(bulletClon, 6);

        yield return new WaitForSeconds(3f);
        isAtacking = false;
        gameObject.GetComponent<Animator>().Play("New State");
    }

    IEnumerator granadeShootAttack()
    {
        isAtacking = true;
        gameObject.GetComponent<Animator>().Play("New State");

        GameObject granadeClon;
        granadeClon = Instantiate(granadePrefab, shootingPivot.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(3f);
        isAtacking = false;
        gameObject.GetComponent<Animator>().Play("New State");
    }

    IEnumerator spawningAttack()
    {

        float spawningRangeX = Random.Range(-innerLongRange, innerLongRange);
        float spawningPosY = transform.position.y - 1;
        float spawningRangeZ = Random.Range(-innerLongRange, innerLongRange);
        Vector3 spawningArea = new Vector3(spawningRangeX, spawningPosY, spawningRangeZ);

        gameObject.GetComponent<Animator>().Play("New State");
        GameObject children;
        children = Instantiate(childPrefab, spawningArea, Quaternion.identity);

        yield return new WaitForSeconds(1f);

        gameObject.GetComponent<Animator>().Play("New State");


    }

    //animaciones

    IEnumerator spawnRoutine()
    {
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(5f);

        gameObject.GetComponent<Animator>().Play("New State");
        isSpawning = false;
    }

    IEnumerator isIdle()
    {
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<Animator>().Play("New State");
        isIdling = false;
    }

    IEnumerator isAtack()
    {
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(3f);

        gameObject.GetComponent<Animator>().Play("New State");
        isAtacking = false;
    }

    //funciones

    private void bossFaseOneBehaviour()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 4)
        {
            rutina = Random.Range(0, 2);
            cronometro = Random.Range(-2, 0);
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

    private void randomNum(int result)
    {
        int ram = Random.Range(0, 100);


    }


    //GizmozDraw

    void OnDrawGizmoz()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerLongRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerLongRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, meeleRange);

    }
}
