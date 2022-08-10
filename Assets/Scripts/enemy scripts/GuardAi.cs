using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAi : MonoBehaviour
{
    public Transform Player;
    public float enemySpeed;
    public bool playerSeen;
    public float rangoDeAlerta;
    public LayerMask player;

    public int rutina;
    public float cronometro;
    //public Animation ani;
    public Quaternion angulo;
    public float grado;

    public Vector3 collision = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);

        playerSeen = Physics.Raycast(transform.position, Vector3.forward, rangoDeAlerta, player);
       
        if (playerSeen == true)
        {
            Vector3 playerPos = new Vector3(Player.position.x, transform.position.y, Player.position.z);
            transform.LookAt(playerPos);
            transform.position = Vector3.MoveTowards(transform.position, playerPos, enemySpeed * Time.deltaTime);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        //Gizmos.DrawRay(transform.position, );
    }
}
