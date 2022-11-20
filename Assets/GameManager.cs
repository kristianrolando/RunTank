using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public float TimerCountDown;
    public Text timeText;

    public Text score;

    public int _score;

    public GameObject gameOverDisp;
    public Text scoreGame;

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

        // Update is called once per frame
        void Update()
    {
        TimerCountDown -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(TimerCountDown / 60);
        float seconds = Mathf.FloorToInt(TimerCountDown % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        score.text = "Score : " +  _score.ToString();
        scoreGame.text = "Score : " +  _score.ToString();

        if(TimerCountDown <= 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        gameOverDisp.SetActive(true);
        Time.timeScale = 0;
    }

    public void AddScore()
    {
        _score += 1;
    }

    public void GotoMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");

    }
}
