using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private BubbleStats bubbleStats;

    public float TimeToBust;

    private void Start()
    {
        bubbleStats = GetComponent<BubbleStats>();
        bubbleStats.OnBust += Busted;
    }

    public void Busted()
    {
        StartCoroutine(Busting());
        gameObject.SetActive(false);
    }

    public IEnumerator Busting()
    {
        yield return new WaitForSeconds(TimeToBust);
    }
}