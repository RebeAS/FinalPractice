using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    public Image TimeFill;
    public Text TimeText;

    public float TimeDuration;
    private float remainingTime;

    public System.Action OnGameOver;
    private BubbleManager bubbleManager;
    private SoundManager soundManager;

    private void Awake()
    {
        bubbleManager = FindObjectOfType<BubbleManager>();
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Start()
    {
        RestartCountdown();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            TimeFill.fillAmount = Mathf.InverseLerp(0, TimeDuration, remainingTime);
            TimeText.text = remainingTime.ToString("0.00");
        }
        else
        {
            remainingTime = 0;
            TimeText.text = remainingTime.ToString("0.00");
            GameOver();
            this.enabled = false;
        }
    }

    public void RestartCountdown()
    {
        remainingTime = TimeDuration;
        TimeFill.fillAmount = 1;
        soundManager.PlayMusic();
        this.enabled = true;
    }

    public void AddExtraTime(float timeAmount)
    {
        remainingTime += timeAmount;
    }

    public void GameOver()
    {
        bubbleManager.StopSpawning();
        soundManager.StopMusic();
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
}