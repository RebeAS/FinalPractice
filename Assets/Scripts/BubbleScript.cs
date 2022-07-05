using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private BubbleStats bubbleStats;
    private SoundManager soundManager;

    public float TimeToBust;

    private void Start()
    {
        bubbleStats = GetComponent<BubbleStats>();
        soundManager = FindObjectOfType<SoundManager>();

        bubbleStats.OnBust += Busted;
    }

    public void Busted()
    {
        StartCoroutine(Busting());
        soundManager.BustingBubbles();
        gameObject.SetActive(false);
    }

    public IEnumerator Busting()
    {
        yield return new WaitForSeconds(TimeToBust);
    }
}