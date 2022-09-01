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
    public float mult = 0;
    public float velocityMultiplier = 0;

    public GameObject particleExplotion;

    public float distancePE;
    public int totalDamage;
    public float explotionDelay = 1;

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
        
        velocityMultiplier += Time.deltaTime;

        if(velocityMultiplier <= 1)
        {
            mult += 0.01f;
        }else if(velocityMultiplier >= 1 && velocityMultiplier <= 2)
        {
            mult += 0.0004f;
        }else if(velocityMultiplier >= 2 && velocityMultiplier <= 3)
        {
            mult += .0007f;
        }else if(velocityMultiplier >= 3 && velocityMultiplier <= 4)
        {
            mult += 0.0009f;
        }else if(velocityMultiplier >= 4 && velocityMultiplier <= 5)
        {
            mult += 0.001f;
        }else if(velocityMultiplier >= 5 && velocityMultiplier <= 6)
        {
            explotion();
        }

        Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
        transform.LookAt(playerPos);
        transform.position = Vector3.MoveTowards(transform.position, playerPos, mult + enemySpeed * Time.deltaTime);

        //atack
        if (prockAttack == true)
        {
            explotion();
            
        }

        distancePE = Vector3.Distance(transform.position, Player.transform.position);

    }

    void explotion()
    {

        explotionDelay -= Time.deltaTime;

        if(explotionDelay < 0)
        {
            if (distancePE >= 0 && distancePE < 1.2)
            {
                HealthBar.vidaActual -= 50;
            }
            else if (distancePE >= 1.2 && distancePE < 1.8)
            {
                HealthBar.vidaActual -= 30;
            }
            else if (distancePE >= 1.8 && distancePE < 2.4)
            {
                HealthBar.vidaActual -= 20;
            }
            else if (distancePE >= 2.4 && distancePE < 3)
            {
                HealthBar.vidaActual -= 10;
            }
            else
            {
                HealthBar.vidaActual -= 0;
            }


            GameObject clon = Instantiate(particleExplotion, transform.position, transform.rotation);
            Destroy(clon, 0.9f);

            Destroy(gameObject);
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
    }
}
