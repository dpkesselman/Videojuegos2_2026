using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public static float time;
    private float initialTime = 120;
    public TextMeshProUGUI textPoints;
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private GameObject textoNavidad;
    [SerializeField] private GameObject textoPerdiste;
    [SerializeField] private GameObject spawner;
    [SerializeField] private GameObject UI;

    private void Start()
    {
        time = initialTime;
    }

    private void Update()
    {
        textPoints.text = "Puntaje: " + score.ToString();
        
        time -= 1 * Time.deltaTime;
        textTime.text = "Tiempo: " + time.ToString("0");

        if (score < 0)
        {
            time = 0;
            Time.timeScale = 0;
            textoPerdiste.SetActive(true);
            score = 0;
        }

        if (time < 0)
        {
            Time.timeScale = 0;
            textoNavidad.SetActive(true);
        }
    }

    public void Reload()
    {
        Destroy(UI);
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}