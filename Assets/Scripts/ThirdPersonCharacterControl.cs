using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterControl : MonoBehaviour
{
    public float Speed = 4f;
    float hor = Input.GetAxis("Horizontal");
    float ver = Input.GetAxis("Vertical");
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        
        Vector3 playerMovement = new Vector3(hor, 0f, ver) * Speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}