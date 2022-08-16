using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAi : MonoBehaviour
{
    //deteccion del jugador
    public float spawningArea, walkingArea;
    bool isSpawning, isMoving;
    public LayerMask capaDelJugador;

    //variables del enemigo
    private Transform Player;
    public float enemySpeed;
    public GameObject childSpawn;

    //rutina

    private int rutina;
    private float cronometro;
    private Quaternion angulo;
    private float grado;

    //spawner
    public float rateOfSpawn = 2f;
    float rateOfSpawnDelta;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        isSpawning = Physics.CheckSphere(transform.position, spawningArea, capaDelJugador);

        isMoving = Physics.CheckSphere(transform.position, walkingArea, capaDelJugador);

        if(isSpawning == true)
        {

            rateOfSpawnDelta -= Time.deltaTime;
            if (rateOfSpawnDelta <= 0)
            {
                GameObject clon = Instantiate(childSpawn, transform.position, Quaternion.identity);
                rateOfSpawnDelta = rateOfSpawn;
            }
        }

        if(isMoving == true)
        {
            ComportamientoEnemigo();
            
        }
    }

    public void ComportamientoEnemigo()
    {
        cronometro += 1 * Time.deltaTime;
        if (cronometro >= 2)
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
        Gizmos.DrawWireSphere(transform.position, spawningArea);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, walkingArea);
        
    }


}
