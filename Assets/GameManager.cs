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
    public GameObject WinOverDisp;
    public GameObject LoseOverDisp;
    public Text scoreGame;

    public static GameManager instance;


    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        TimerCountDown = 0;
        Time.timeScale = 1;
       // AudioPlayer.instance.Play("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        TimerCountDown += Time.deltaTime;

        float minutes = Mathf.FloorToInt(TimerCountDown / 60);
        float seconds = Mathf.FloorToInt(TimerCountDown % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        score.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        scoreGame.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }

    public void GameOver()
    {
        AudioPlayer.instance.Play("win");
        gameOverDisp.SetActive(true);
        LoseOverDisp.SetActive(true);
        Time.timeScale = 0;
    }

    public void AddScore()
    {
        _score += 1;
    }

    public void GotoMenu(string ala)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(ala);

    }

    public void Win()
    {
        AudioPlayer.instance.Play("win");
        gameOverDisp.SetActive(true);
        WinOverDisp.SetActive(true);
        Time.timeScale = 0;
    }
}
