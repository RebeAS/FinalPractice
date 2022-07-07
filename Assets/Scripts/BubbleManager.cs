using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public BubblePool[] MyBubblePools;

    public Transform[] SpawnPositions;
    public float TimeToSpawn;

    public int MaxNumBubbles;
    private int currentNumBubbles;

    private void Start()
    {
        StartSpawning();
    }

    public void StartSpawning()
    {
        StartCoroutine(SpawnCoroutine());
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }

    public IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeToSpawn);
            if (!TooManyBubbles())
            {
                int randomPosition = Random.Range(0, SpawnPositions.Length);
                int randomPool = Random.Range(0, MyBubblePools.Length);
                GameObject pooledBubble = MyBubblePools[randomPool].GetBubbleFromPool(SpawnPositions[randomPosition].position, SpawnPositions[randomPosition].rotation);
                pooledBubble.SetActive(true);
                currentNumBubbles++;
            }
        }
    }

    public bool TooManyBubbles()
    {
        if (currentNumBubbles == MaxNumBubbles)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BubbleBust()
    {
        currentNumBubbles--;
    }
}