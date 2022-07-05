using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text MaxScore;
    public Text ScoreText;
    public Text NewRecord;
    public Text BubbleBustedText;

    public int CurrentScore = 0;
    public int BustedBubble = 0;

    private CountDown countDown;
    private SoundManager soundManager;

    private void Awake()
    {
        countDown = FindObjectOfType<CountDown>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        ResetScore();
        ShowMaxScore();
        countDown.OnGameOver += CheckMaxScore;
        countDown.OnGameOver += ShowMaxScore;
    }

    private void Update()
    {
        ScoreText.text = CurrentScore.ToString("00000");
        BubbleBustedText.text = BustedBubble.ToString("000");
    }

    public void ResetScore()
    {
        CurrentScore = 0;
        BustedBubble = 0;
        soundManager.StopVictorySound();
        NewRecord.enabled = false;
    }

    public void WinPoints(int pointsAmount)
    {
        CurrentScore += pointsAmount;
    }

    public void AddBustedBubble()
    {
        BustedBubble++;
    }

    public void CheckMaxScore()
    {
        int score = PlayerPrefs.GetInt("MaxScore");
        if (score < CurrentScore)
        {
            PlayerPrefs.SetInt("MaxScore", CurrentScore);
            MaxScore.text = score.ToString("00000");
            soundManager.BreakingRecords();
            NewRecord.enabled = true;
        }
    }

    public void ShowMaxScore()
    {
        MaxScore.text = PlayerPrefs.GetInt("MaxScore").ToString("00000");
    }
}