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

    private void Start()
    {
        RestartCountdown();
        bubbleManager = FindObjectOfType<BubbleManager>();
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
            GameOver();
            this.enabled = false;
        }
    }

    public void RestartCountdown()
    {
        remainingTime = TimeDuration;
        TimeFill.fillAmount = 1;
        this.enabled = true;
    }

    public void AddExtraTime(float timeAmount)
    {
        remainingTime += timeAmount;
    }

    public void GameOver()
    {
        bubbleManager.StopSpawning();
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }
}