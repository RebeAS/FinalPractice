using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource BackgroundMusic;
    public AudioSource ClickBubble;
    public AudioSource BubbleBust;
    public AudioSource NewRecord;

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        BackgroundMusic.Play();
    }

    public void StopMusic()
    {
        BackgroundMusic.Stop();
    }

    public void ClickingBubbles()
    {
        ClickBubble.Play();
    }

    public void BustingBubbles()
    {
        BubbleBust.Play();
    }

    public void BreakingRecords()
    {
        NewRecord.Play();
    }

    public void StopVictorySound()
    {
        NewRecord.Stop();
    }
}