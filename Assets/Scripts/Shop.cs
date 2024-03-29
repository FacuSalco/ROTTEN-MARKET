﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public float range;
    public LayerMask player;
    [SerializeField] bool isNear;
    public GameObject shopCanvas, playerCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isNear = Physics.CheckSphere(transform.position, range, player);
        
        if (Input.GetKeyDown(KeyCode.E) && isNear)
        {
            PauseBehaviour.gameIsPaused = true;
            shopCanvas.SetActive(true);
            playerCanvas.SetActive(false);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
