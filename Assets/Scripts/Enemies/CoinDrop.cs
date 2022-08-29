using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDrop : MonoBehaviour
{
    //coin set up
    private Vector3 velocity = Vector3.up;
    private Rigidbody rb;
    private Vector3 startPos;
    private Collider hitBox;

    bool isOnGround;
    bool activateHit;

    [SerializeField] private float speed = 2f;
    [SerializeField] private float height = 0.4f;
    [SerializeField] private float rotationSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
        startPos += new Vector3(Random.Range(-0.5f,1f), 0f, Random.Range(-0.5f,1f));
        velocity *= (Random.Range(6f, 12f));
        velocity += new Vector3(Random.Range(-1f, 1f),0 , Random.Range(-1f, 1f));

        rb = this.GetComponent<Rigidbody>();
        hitBox = this.GetComponent<SphereCollider>();

        hitBox.enabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;

        rb.AddForce(velocity, ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOnGround == true)
        {
            if (activateHit == false)
            {
                StartCoroutine(activateHitbox());
                activateHit = true;
            }
            

            rb.isKinematic = true;
            rb.useGravity = false;
            

            float newY = Mathf.Sin(Time.time * speed) * height + startPos.y;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);

            transform.eulerAngles += new Vector3(0f, rotationSpeed, 0f);

        }

    }

    IEnumerator activateHitbox()
    {

        yield return new WaitForSeconds(3f);

        hitBox.enabled = false;
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.gameObject == true)
        {
            isOnGround = true;
        }
    }

}
