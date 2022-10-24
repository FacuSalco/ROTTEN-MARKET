using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePosition : MonoBehaviour
{
    private Vector3 defaultPos;
    private Vector3 defaultRot;

    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
        defaultRot = transform.eulerAngles;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartTransform()
    {
        transform.position = defaultPos;
        transform.eulerAngles = defaultRot;
    }
}
