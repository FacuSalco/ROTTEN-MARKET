using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCanvas : MonoBehaviour
{
    private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.rotation = Quaternion.LookRotation(cam.transform.position - transform.position);
    }
}
