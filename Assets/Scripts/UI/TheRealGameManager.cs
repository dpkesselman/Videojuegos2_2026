using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TheRealGameManager : MonoBehaviour
{
    private GameObject pauseButton;
    private GameObject pauseMenu;
    public static TheRealGameManager instance;
    
    private bool isPaused = false; // Booleano para pausar y reanudar con un botón

    void Awake()
    {
        //Código para que la instancia no se repita por error
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void PlayFragmentado()
    {
        SceneManager.LoadScene("Platformer_LVL1");
    }

    public void PlayCieloRojo()
    {
        SceneManager.LoadScene("TopDown_LVL1");
    }
    
    public void Pause()
    {
        isPaused = true; 
        Time.timeScale = 0f;
        pauseButton.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pauseButton.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}