using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    //coin set up
    private Vector3 velocity = Vector3.up;
    private Rigidbody rb;
    private Vector3 startPos;
    
    bool isOnGround;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float height = 0.4f;
    [SerializeField] private float rotationSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        velocity *= (Random.Range(6f, 12f));
        velocity += new Vector3(Random.Range(-1f, 1f),0 , Random.Range(-1f, 1f));

        rb = this.GetComponent<Rigidbody>();

        rb.AddForce(velocity, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOnGround == true)
        {

            rb.isKinematic = true;
            rb.useGravity = false;
            

            float newY = Mathf.Sin(Time.time * speed) * height + startPos.y;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            transform.eulerAngles += new Vector3(0f, rotationSpeed, 0f);

        }

    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject == true)
        {
            isOnGround = true;
        }
    }

}
