using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyNavMeshController : MonoBehaviour
{
    public float walkSpeedSet;
    public float runSpeedSet;

    private static float walkSpeed;
    private static float runSpeed;
    private static NavMeshAgent agent;
    private static Transform Player;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public static void navWalk()
    {
        EnemyNavMeshController.agent.destination = EnemyNavMeshController.Player.position;
        EnemyNavMeshController.agent.speed = EnemyNavMeshController.walkSpeed; 
    }

    public static void navRun()
    {
        EnemyNavMeshController.agent.destination = EnemyNavMeshController.Player.position;
        EnemyNavMeshController.agent.speed = EnemyNavMeshController.runSpeed;
    }


}
