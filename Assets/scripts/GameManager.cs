using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int live = 3;
    public int score = 0;
    public int highscore = 0;
    public Text scoreText;
    public Text liveText;
    public Text highscoreText;
    private void Start()
    {
        live = PlayerPrefs.GetInt("Lives", 3);
        score = PlayerPrefs.GetInt("Score", 0);
    }
    public void AddScore(int points)
    {
        // Sumar puntos y actualizar el HUD
        score += points;
        UpdateScoreText();
    }
    public void loselive()
    {
        live--;
        if (live <= -1)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            ResetLevel();
        }
    }

    public void ResetLevel()
    {
        FindAnyObjectByType<player>().ResetPlayer();
        FindAnyObjectByType<pelota>().ResetBall();
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("Level1"); 
    }
    public void Continue()
    {
       string lastLevel = PlayerPrefs.GetString("lastLevel");
       

        if (lastLevel == "Level1")
        {
            SceneManager.LoadScene("level2");
            
        }
        else if(lastLevel == "level2")
        {
            SceneManager.LoadScene("level1");
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
    private void UpdateScoreText()
    {
        scoreText.text = "score " + score;  // Mostrar el puntaje actualizado
        liveText.text = "Lives " + live;
    }
    public void Pause()
    {
        PlayerPrefs.SetInt("Lives", live);
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("childs", transform.childCount);
        PlayerPrefs.Save();
        SceneManager.LoadScene("pauseMenu");

    }
    public void Resume()
    {
        live = PlayerPrefs.GetInt("Lives", 3);
        score = PlayerPrefs.GetInt("Score", 0);
        string lastLevel = PlayerPrefs.GetString("lastLevel");
        if (lastLevel == "Level1")
        {
            SceneManager.LoadScene("level1");

        }
        else if (lastLevel == "level2")
        {
            SceneManager.LoadScene("level2");
        }
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }
    public void CheckComplete()
    {
        if (transform.childCount <= 1)
        {
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
           PlayerPrefs.SetInt("Lives", live);
           PlayerPrefs.SetInt("Score", score);
           PlayerPrefs.Save();
           SceneManager.LoadScene("Win");
        }
    }
}
