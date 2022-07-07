using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    public GameObject PauseObject;

    private SoundManager soundManager;

    private void Start()
    {
        PauseObject.SetActive(false);
        soundManager = FindObjectOfType<SoundManager>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            isPaused = true;
            PauseObject.SetActive(true);
            soundManager.PauseMusic();
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            PauseObject.SetActive(false);
            soundManager.UnpauseMusic();
        }
    }
}