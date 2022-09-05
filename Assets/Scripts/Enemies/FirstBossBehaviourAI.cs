using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstBossBehaviourAI : MonoBehaviour
{
    //setUp
    [Header("Player Reference")]
    private Transform Player;
    public LayerMask capaDelJugador;

    [Header("Ghost body")]
    public GameObject ghostChildren;
    private Transform ghostChildrenTransform;

    //rangos
    [Header("Ranges")]
    public float outerLongRange;
    public float innerLongRange;
    public float meeleRange;
    private bool outerRangeBool, innerRangeBool, meeleRangeBool;

    //fases del enemigo

    private bool isSpawning = true;
    private bool firstFase = false;
    private bool secondFase = false;
    private bool isDying = false;

    //boss-rest
    private float attackingTime;
    private float attackingTimeDelta;
    private float restingTime;
    private float restingTimeDelta;
    private bool isResting = false;

    //anim
    private bool isAnimating = false;
    private bool isIdling = false;
    private bool isAtacking = false;
    private bool idleOnce = true;
    private bool isShootingGranade = false;
    private bool isReadyToShoot = false;

    //Turret
    [Header("Shooting")]
    public Transform shootingPivot;
    public GameObject bulletPrefab;
    public GameObject granadePrefab;
    public float shootingRateOfAttack;
    private float shootingRateOfAttackDelta;
    public float granadeRateOfAttack;
    private float granadeRateOfAttackDelta;
    private float shootingCount;

    //spawner
    [Header("Spawning")]
    public GameObject childPrefab;
    public float spawningRate;
    private float spawningRateDelta;

    //teleport
    [Header("Teleport Area")]
    public float tpAreaX;
    public float tpAreaZ;

    //rutina
    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grado;

    //behaviour
    [Header("Behaviour")]
    private bool canLookToPlayer = true;

    //Vida

    private EnemyHealthBar healthBarController;
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        healthBarController = GetComponent<EnemyHealthBar>();

        StartCoroutine(spawnRoutine());

        attackingTime = attackingTimeDelta;
        restingTime = restingTimeDelta;
    }

    // Update is called once per frame
    void Update()
    {
        ghostChildren.transform.LookAt(Player);   

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

            if (isDying)
            {
                StartCoroutine(isDie());
            }

        }

        //crequea si esta haciendo alguna animacion
        if(isSpawning || isIdling || isAtacking || isDying || isResting)
        {
            isAnimating = true;
        }
        else
        {
            isAnimating = false;
        }

        //tiempo de ataque y tiempo de descanso
        attackingTime -= Time.deltaTime;
        if(attackingTime < 0)
        {

            isResting = true;

            if (isResting)
            {
                restingTime -= Time.deltaTime;
                if(restingTime < 0)
                {
                    isResting = false;
                    attackingTime = attackingTimeDelta;
                    restingTime = restingTimeDelta;
                }
            }
        }

        //primera fase
        if (firstFase)
        {
            if (outerRangeBool)
            {
                if (!isAnimating)
                {

                    if (canLookToPlayer)
                    {
                        transform.LookAt(Player);
                    }

                    //spawningChildren
                    spawningRateDelta -= Time.deltaTime;
                    if (spawningRateDelta < 0)
                    {
                        StartCoroutine(spawningAttack());
                        spawningRateDelta = spawningRate;
                    }


                    //bullet-shooting
                    if (!isShootingGranade)
                    {

                        shootingRateOfAttackDelta -= Time.deltaTime;
                        if (shootingRateOfAttackDelta < 0)
                        {
                            if (shootingCount < 6)
                            {
                                shoot();
                                shootingRateOfAttackDelta = shootingRateOfAttack;
                                shootingCount++;
                            }
                            else
                            {
                                isShootingGranade = true;

                            }
                        }
                    }
                    //granade-spawner
                    if (isShootingGranade)
                    {
                        StartCoroutine(chargingGranade());
                    }
                }

            } else if (innerRangeBool)
            {
                if (!isAnimating)
                {

                    //spawningChildren
                    spawningRateDelta -= Time.deltaTime;
                    if (spawningRateDelta < 2)
                    {
                        StartCoroutine(spawningAttack());
                        spawningRateDelta = spawningRate;
                    }

                    //bullet-shooting
                    shootingRateOfAttackDelta -= Time.timeScale;
                    if (shootingRateOfAttack < 0)
                    {
                        StartCoroutine(bulletShootAttack());
                        shootingRateOfAttackDelta = shootingRateOfAttack;
                    }
                }

            }

            if(!outerRangeBool && !innerRangeBool)
            {
                if (idleOnce)
                {
                    StartCoroutine(isIdle());
                }
            }
           
        }

        if (secondFase)
        {
            if (outerRangeBool && !innerRangeBool)
            {

                if (!isAnimating)
                {
                   


                }

            }
            else if (innerRangeBool)
            {

            }
            else
            {
                if (idleOnce)
                {
                    StartCoroutine(isIdle());
                }
            }
        }
        

    }

    //bullet-shoot

    private void shoot()
    {
        StartCoroutine(bulletShootAttack());

        GameObject bulletClon;
        bulletClon = Instantiate(bulletPrefab, shootingPivot.transform.position, transform.rotation);
        Destroy(bulletClon, 6);
    }

    IEnumerator bulletShootAttack()
    {
        isAtacking = true;
        gameObject.GetComponent<Animator>().Play("New State");
        
        yield return new WaitForSeconds(1f);
        isAtacking = false;
        gameObject.GetComponent<Animator>().Play("New State");
    }

    //granade-instantiate

    private void granadeShoot()
    {
        StartCoroutine(granadeShootAttack());

        GameObject granadeClon;
        granadeClon = Instantiate(granadePrefab, shootingPivot.transform.position, Quaternion.identity);
        float propulsionForce = Random.Range(7f, 15f);
        granadeClon.GetComponent<Rigidbody>().AddForce(shootingPivot.transform.forward * propulsionForce, ForceMode.Impulse);
    }

    IEnumerator chargingGranade()
    {
        isAtacking = true;
        float timer = 0.7f;
        float deltaTime = timer;
        deltaTime -= Time.deltaTime;

        if(deltaTime > 0)
        {
            transform.LookAt(Player);
        }
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(1f);

        granadeShoot();
    }

    IEnumerator granadeShootAttack()
    {
        isAtacking = true;
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(2f);

        shootingCount = 0;
        isAtacking = false;
        isShootingGranade = false;
        gameObject.GetComponent<Animator>().Play("New State");
    }

    //spawning

    IEnumerator spawningAttack()
    {
        isAtacking = true;
        gameObject.GetComponent<Animator>().Play("New State");
 
        int childAmount = randomNum();
        for(int i = 0; i <= childAmount; i++)
        {
            float spawningRangeX = Random.Range(-innerLongRange, innerLongRange);
            float spawningPosY = transform.position.y;
            float spawningRangeZ = Random.Range(-innerLongRange, innerLongRange);
            Vector3 spawningArea = new Vector3(spawningRangeX, spawningPosY, spawningRangeZ);

            GameObject children;
            children = Instantiate(childPrefab, spawningArea, Quaternion.identity);
        }

        yield return new WaitForSeconds(2f);
        isAtacking = false;
        gameObject.GetComponent<Animator>().Play("New State");
    }

    IEnumerator teleportBoss()
    {
        isAtacking = true;
        float tpRangeX = Random.Range(-tpAreaX, tpAreaX);
        float tpPosY = transform.position.y;
        float tpRangeZ = Random.Range(-tpAreaZ, tpAreaZ);
        Vector3 spawningPos = new Vector3(tpRangeX, tpPosY, tpRangeZ);

        transform.position = spawningPos;

        
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(3f);

        isAtacking = false;
        gameObject.GetComponent<Animation>().Play("New State");
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
        idleOnce = false;
        isIdling = true;
        gameObject.GetComponent<Animator>().Play("idle");

        yield return new WaitForSeconds(1.3f);

        gameObject.GetComponent<Animator>().Play("New State");
        isIdling = false;
        idleOnce = true;
    }

    IEnumerator isDie()
    {
        isDying = true;
        gameObject.GetComponent<Animator>().Play("New State");

        yield return new WaitForSeconds(3f);

        gameObject.GetComponent<Animator>().Play("New State");
        isDying = false;
    }

    //funciones

    int randomNum()
    {
        int ram = Random.Range(0, 100);
        int result = 0;

        if(ram < 80)
        {
            result = 0;
        }
        else
        {
            result = 1;
        }

        return result;
    }


    //GizmozDraw

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, outerLongRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, innerLongRange);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, meeleRange);

    }
}
