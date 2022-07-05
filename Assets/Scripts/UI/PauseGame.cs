using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    private bool isPaused;
    public GameObject PauseObject;

    private void Start()
    {
        PauseObject.SetActive(false);
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
        }
        else
        {
            Time.timeScale = 1;
            isPaused = false;
            PauseObject.SetActive(false);
        }
    }
}
