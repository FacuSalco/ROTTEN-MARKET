using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcFollowerScritp : MonoBehaviour
{
    private EnemyNavMeshController navController;
    private bool NpcDoFollow = true;

    // Start is called before the first frame update
    void Start()
    {
        navController = GetComponent<EnemyNavMeshController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NpcDoFollow)
        {
            navController.navWalk();
        }


    }
}
