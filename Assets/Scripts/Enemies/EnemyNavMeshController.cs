using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavMeshController : MonoBehaviour
{
   
    public float walkSpeed;
    public float runSpeed;
    private NavMeshAgent agent;
    private Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void navWalk()
    {
        agent.destination = Player.position;
        agent.speed = walkSpeed; 
    }

    public void navRun()
    {
        agent.destination = Player.position;
        agent.speed = runSpeed;
    }

    public void navRunAccesible(float speed)
    {
        agent.destination = Player.position;
        agent.speed = speed;
    }


}
