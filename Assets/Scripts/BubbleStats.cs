using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStats : MonoBehaviour
{
    public LayerMask LimitsMask;

    public float MaxHP;
    private float currentHP;

    public int WinPoints;
    public float ExtraTime;

    public float Speed;
    public float Frequency;
    public float Magnitude;
    private Vector3 posY;
    private Vector3 axisY;

    public System.Action OnBust;
    private BubbleManager bubbleManager;
    private ScoreManager scoreManager;
    private CountDown countDown;
    private SoundManager soundManager;

    private void Start()
    {
        posY = transform.position;
        axisY = transform.up;

        bubbleManager = FindObjectOfType<BubbleManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        countDown = FindObjectOfType<CountDown>();
        soundManager = FindObjectOfType<SoundManager>();

        countDown.OnGameOver += DeactivateBubble;
    }

    private void Update()
    {
        posY += transform.right * Time.deltaTime * Speed;
        transform.position = posY + axisY * Mathf.Sin(Time.time * Frequency) * Magnitude;
    }

    private void OnEnable()
    {
        currentHP = MaxHP;
    }

    public void DeactivateBubble()
    {
        gameObject.SetActive(false);
        bubbleManager.BubbleBust();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, LimitsMask))
        {
            gameObject.SetActive(false);
        }

        bubbleManager.BubbleBust();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Utils.IsInLayerMask(collision.gameObject, LimitsMask))
        {
            gameObject.SetActive(false);
        }

        bubbleManager.BubbleBust();
    }

    private void OnMouseDown()
    {
        TakeDamage();
        soundManager.ClickingBubbles();
    }

    public void TakeDamage()
    {
        currentHP--;
        if (currentHP <= 0)
        {
            bubbleManager.BubbleBust();
            scoreManager.WinPoints(WinPoints);
            scoreManager.AddBustedBubble();
            countDown.AddExtraTime(ExtraTime);

            if (OnBust != null)
            {
                OnBust();
            }
        }
    }
}