using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeManager : MonoBehaviour
{
    public GameObject cuboGanador;

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

            Debug.Log("Todos apretaDos");//poner logica cuando esten todos
            cuboGanador.SetActive(true);
        }
    }
}
