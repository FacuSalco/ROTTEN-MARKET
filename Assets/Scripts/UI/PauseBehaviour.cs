using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    public GameObject pauseMenuUI, optionsMenuUI, menuMenuUI, shopCanvasUI, playerCanvas;
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
            if (gameIsPaused) //Si esta en pausa
            {
                Resume();
                //canvases.SetActive(false);
            }

            else //Si no esta en pausa
            {
                Pause();
                //canvases.SetActive(true);
            }
        }
    }

    public void Resume() // CUANDO SACO PAUSA
    {
        gameIsPaused = false;
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        menuMenuUI.SetActive(false);
        shopCanvasUI.SetActive(false);
        playerCanvas.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //DECIRLE A CIRO QUE PONGA QUE CUANDO EL PLAYER TOCA MOUSE.IZQ PARA PEGAR QUE VERIFIQUE QUE EL JUEGO NO ESTE PAUSADO. PORQUE SI NO EL CHABON PEGA CUANDO CLICKEO PARA SACAR PAUSA

    public void Pause() // CUANDO PONGO PAUSA
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Quit()
    {
        Application.Quit(); //SOLO ANDA CUANDO EL JUEGO ESTA BILDEADO, PERO SI ANDA
    }

    public void Menu()
    {
        menuMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);

    }

    public void Options() //PARA EDITAR LAS OPCIONES DEL JUEGO
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
    }

    public void ReturnToPauseMenu()
    {
        if (menuMenuUI.activeInHierarchy)
        {
            menuMenuUI.SetActive(true);
        }

        else
        {
            pauseMenuUI.SetActive(true);
        }

        optionsMenuUI.SetActive(false);
    }

    public void StartGame()
    {
        menuMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        gameIsPaused = false;
    }

}