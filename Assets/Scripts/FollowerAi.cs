using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowerAi : MonoBehaviour
{
    public float rangoDeAlerta;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    public Transform Player;
    public float enemySpeed;



    public float time = 2;
    bool attackCooldown = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        estarAlerta = Physics.CheckSphere(transform.position, rangoDeAlerta, capaDelJugador);

        if (estarAlerta == true)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
        }


        //puede atacar cada 2 segundos
        if (attackCooldown == true)
        {
            time -= Time.deltaTime;

            if (time == 0)
            {
                attackCooldown = false;
                time = 2;
            }

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangoDeAlerta);

    }

}
