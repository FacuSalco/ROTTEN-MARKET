using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    public GameObject pauseMenuUI, optionsMenuUI, menuMenuUI, canvases;
    public static bool gameIsPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canvases.activeInHierarchy)
            {
                Time.timeScale = 0f;
                gameIsPaused = true;
            }
            else if (!canvases.activeInHierarchy)
            {
                Time.timeScale = 1f;
                gameIsPaused = false;
            }
            

            if (gameIsPaused) //Si esta en pausa
            {
                Resume();
            }
            else if (!gameIsPaused) //Si no esta en pausa
            {
                Pause();
            }
        }
    }

    public void Resume() // CUANDO SACO PAUSA
    {
        canvases.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    //DECIRLE A CIRO QUE PONGA QUE CUANDO EL PLAYER TOCA MOUSE.IZQ PARA PEGAR QUE VERIFIQUE QUE EL JUEGO NO ESTE PAUSADO. PORQUE SI NO EL CHABON PEGA CUANDO CLICKEO PARA SACAR PAUSA
    
    public void Pause() // CUANDO PONGO PAUSA
    {
        pauseMenuUI.SetActive (true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit(); //SOLO ANDA CUANDO EL JUEGO ESTA BILDEADO, PERO SI ANDA
    }

    public void Menu()
    {
        canvases.SetActive(false);
        menuMenuUI.SetActive(true);
    }

    public void Options() //PARA EDITAR LAS OPCIONES DEL JUEGO
    {
        canvases.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(false);
    }

    public void StartGame()
    {
        canvases.SetActive(false);
        //ASIGNARLO AL BOTON DE START EN EL CANVAS DEL MENU
        //ASIGNAR LOS GAMEOBJECTS QUE FALTAN (menuMenuUI, canvases)
    }

}
