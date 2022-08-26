using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ChangeConfigs : MonoBehaviour
{
    public CinemachineFreeLook cineCam;
    public float sensitivityX, sensitivityY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //HACER LA BARRITA PARA QUE EL CHABON PUEDA ELEGIR LA SENSIBILIDAD CAMBIANDO LAS VARIABLES ESTAS DE SENSITIVITI
        cineCam.m_XAxis.m_MaxSpeed = 30 * sensitivityX;
        cineCam.m_YAxis.m_MaxSpeed = sensitivityY / 3;
    }
}
