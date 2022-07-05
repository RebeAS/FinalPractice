using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reset : MonoBehaviour
{
    public Text MaxScore;

    private void Start()
    {
        Restart();
    }

    public void Restart()
    {
        MaxScore.text = PlayerPrefs.GetInt("MaxScore").ToString("00000");
    }

    public void ResetScore()
    {
        PlayerPrefs.SetInt("MaxScore", 0);
        Restart();
    }
}