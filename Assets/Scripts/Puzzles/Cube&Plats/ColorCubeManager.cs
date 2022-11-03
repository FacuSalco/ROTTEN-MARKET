using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeManager : MonoBehaviour
{
    public GameObject persiana;

    public List<ColorCubes> AllMyCubes;
    
    void Start()
    {
        foreach (var cube in AllMyCubes)
        {
            cube.CCM = this;
        }
    }

    public void CubeIsPressed(ColorCubes cube)
    {
        if(AllMyCubes.Contains(cube))
        {
            foreach (var cuboActual in AllMyCubes)
            {
                if(!cuboActual.isOk)
                {
                    return;
                }
            }

            persiana.GetComponent<Animator>().Play("AbrirPersiana3");
            Debug.Log("Todos apretados");//poner logica cuando esten todos apretados
        }
    }
}
