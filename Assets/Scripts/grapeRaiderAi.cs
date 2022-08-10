using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grapeRaiderAi : MonoBehaviour
{
    public LayerMask capaDelJugador;
    private Transform Player;
    public float enemySpeed;
    public float rangoDeAtaque;
    bool prockAttack;

    public GameObject blockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        prockAttack = Physics.CheckSphere(transform.position, rangoDeAtaque, capaDelJugador);

        //chasing player

        Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
        transform.LookAt(playerPos);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);


        //atack
        if (prockAttack == true)
        {

            int counter = 0;
            while (counter <= 4)
            {
                GameObject clon = Instantiate(blockPrefab, transform.position, Quaternion.identity);

                Destroy(clon, 4);

                counter++;

                if (counter <= 3)
                {
                    Destroy(gameObject);
                }
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
    }
}
