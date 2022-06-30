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
    public AudioSource audio;
    public AudioSource audio2;
    public AudioClip bgmClip;
    public AudioClip gameoverClip;

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

        audio2.clip = bgmClip;
        audio2.Play();
        audio.clip = gameoverClip;
        audio.Stop();

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
        audio2.clip = bgmClip;
        audio2.Stop();
        
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();

        audio.clip = gameoverClip;
        audio.Play();
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
