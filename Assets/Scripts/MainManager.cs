using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
       
    public void PlayFragmentado()
    {
        SceneManager.LoadScene("Platformer_LVL1");
    }

    public void PlayCieloRojo()
    {
        SceneManager.LoadScene("TopDown_LVL1");
    }

        
    public void Quit()
    {
        Application.Quit();
    }

}