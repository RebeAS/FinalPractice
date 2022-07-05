using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public GameObject ContinueObject;

    private CountDown countDown;
    private BubbleManager bubbleManager;
    private ScoreManager scoreManager;

    private void Start()
    {
        ContinueObject.SetActive(false);

        countDown = FindObjectOfType<CountDown>();
        bubbleManager = FindObjectOfType<BubbleManager>();
        scoreManager = FindObjectOfType<ScoreManager>();

        countDown.OnGameOver += ActivateMenu;
    }

    public void ActivateMenu()
    {
        ContinueObject.SetActive(true);
    }

    public void Restart()
    {
        bubbleManager.StartSpawning();
        scoreManager.ResetScore();
        countDown.RestartCountdown();

        ContinueObject.SetActive(false);
    }
}
