using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int score;
    private int highScore;

    public Player player;
    public Text scoreText;
    public Text highScoreText;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        gameOver.SetActive(false);
        highScore = 0;
        highScoreText.text = "HIGHSCORE: " + highScore.ToString();

        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        gameOver.SetActive(false);
        playButton.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for(int i=0; i<pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore.ToString();
        }
    }


}
