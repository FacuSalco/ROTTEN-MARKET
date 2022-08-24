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

    private bool firstFase = true;
    private bool secondFase = false;
    private bool isDying = false;

    //reloj

    private float rateOfAttack;
    private float rateOfAttackDelta;

    //Vida

    private EnemyHealthBar healthBarController;
    private float health;
    
    // Start is called before the first frame update
    void Start()
    {
        healthBarController = GetComponent<EnemyHealthBar>();
        

    }

    // Update is called once per frame
    void Update()
    {
        health = healthBarController.currentHealth;

        outerRangeBool = Physics.CheckSphere(transform.position, outerLongRange, capaDelJugador);
        innerRangeBool = Physics.CheckSphere(transform.position, innerLongRange, capaDelJugador);
        meeleRangeBool = Physics.CheckSphere(transform.position, meeleRange, capaDelJugador);
        
        if(health >= health / 2)
        {
            firstFase = true;
        }
        else if(health <= health / 2)
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
}
