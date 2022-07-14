using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAi : MonoBehaviour
{

    //variables
    public float rangoDeAlerta, rangoDeAlerta2;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    bool estarAlerta2;
    public Transform Player;
    public float enemySpeed;
    public float enemySpeed2;


    //attack
    public float rangoDeAtaque;
    bool prockAttack;
    public float time = 2;
    bool attackCooldown = false;
    public Transform sword;
    bool attackAn = false;

    //rutina

    public int rutina;
    public float cronometro;
    //public Animation ani;
    public Quaternion angulo;
    public float grado;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        estarAlerta2 = Physics.CheckSphere(transform.position, rangoDeAlerta2, capaDelJugador);

        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);

        if (estarAlerta == true)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);

            //run anim
        }

        if(estarAlerta2 == true && estarAlerta == false)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);

            //walk anim
        }

        if(estarAlerta == false && estarAlerta2 == false)
        {
            ComportamientoEnemigo();
        }

        

        if(prockAttack == true)
        {
            if(attackAn == false)
            {
                //atack anim
                attackAn = true;
            }
            
            if(attackAn == true)
            {
                time -= Time.deltaTime;

                if (time <= 0)
                {
                    attackAn = false;
                }
            }

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
    }

}
