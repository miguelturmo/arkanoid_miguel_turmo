using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int live = 3;
    public int score;
    public int highscore = 0;
    public Text scoreText;
    public Text liveText;
    public Text highscoreText;
    private void Start()
    {
        live = PlayerPrefs.GetInt("Lives", 3);
        score = PlayerPrefs.GetInt("Score", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
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
            checkHighscore();
            PlayerPrefs.SetInt("Score", score);
            PlayerPrefs.SetInt("Lives", live);
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
        checkHighscore();
        PlayerPrefs.DeleteKey("Lives");
        PlayerPrefs.DeleteKey("Score");
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
        highscoreText.text = "HighScore " + highscore;
    }
    public void Pause()
    {
        PlayerPrefs.SetInt("Lives", live);
        PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("childs", transform.childCount);
        checkHighscore();
        PlayerPrefs.Save();
        SceneManager.LoadScene("pauseMenu");

    }
    public void Resume()
    {
        live = PlayerPrefs.GetInt("Lives", 3);
        score = PlayerPrefs.GetInt("Score", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
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
        PlayerPrefs.DeleteKey("Score");
        PlayerPrefs.DeleteKey("Lives");
        checkHighscore();
        PlayerPrefs.Save();
        SceneManager.LoadScene("Mainmenu");
    }
    public void StartGame()
    {

        SceneManager.LoadScene("Level1");
    }
    public void CheckComplete()
    {
        if (transform.childCount <= 1)
        {
           //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           PlayerPrefs.SetString("lastLevel", SceneManager.GetActiveScene().name);
            checkHighscore();
            PlayerPrefs.SetInt("Lives", live);
           PlayerPrefs.SetInt("Score", score);
            
           PlayerPrefs.Save();
           SceneManager.LoadScene("Win");
        }
    }
    public void checkHighscore()
    {
        if (score > highscore)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        else
        {
            PlayerPrefs.SetInt("highscore", highscore);
        }
    }
}
