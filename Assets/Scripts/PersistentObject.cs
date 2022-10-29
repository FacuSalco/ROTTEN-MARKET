using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObject : MonoBehaviour
{

    public static PersistentObject instance;

    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(gameObject);

        //if (instance == null)
        //{
        //    instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
