using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raiderAi : MonoBehaviour
{

    public float rangoDeAlerta, rangoDeAlerta2;
    public LayerMask capaDelJugador;
    bool estarAlerta;
    bool estarAlerta2;
    public Transform Player;
    public float enemySpeed;
    public float enemySpeed2;
    public float rangoDeAtaque;
    bool prockAttack;
    bool stopChasing;

    public GameObject blockPrefab;
   


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

        if (estarAlerta == true && prockAttack == false && stopChasing == false)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);

            //run anim
        }

        if (estarAlerta2 == true && estarAlerta == false && stopChasing == false)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed2 * Time.deltaTime);

            //walk anim
        }

        if (estarAlerta == false && estarAlerta2 == false)
        {
            //sleep anim
        }

        if (prockAttack == true)
        {
            stopChasing = true;

            int counter = 0;
            while(counter <= 4)
            {
                GameObject clon = Instantiate(blockPrefab, transform.position, Quaternion.identity);

                Destroy(clon, 4);

                counter++;

                if(counter <= 3)
                {
                    Destroy(gameObject);
                }
            }

         
            //attack anim
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
