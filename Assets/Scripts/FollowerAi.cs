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
        }

        if(estarAlerta2 == true && estarAlerta == false)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);
        }

        //todavia no funk esto

        if(prockAttack == true)
        {
            if(attackAn == false)
            {
                for (int i = 0; i <= 12; i++)
                {
                    sword.transform.eulerAngles -= new Vector3(1, 0, 0);
                    if (i == 12)
                    {
                        attackAn = true;
                    }
                }
            }
            if(attackAn == true)
            {
                for (int i = 0; i <= 12; i++)
                {
                    sword.transform.eulerAngles += new Vector3(1, 0, 0);
                    if(i == 12)
                    {
                        attackAn = false;
                    }
                }
            }
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
