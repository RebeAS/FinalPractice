using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePool : MonoBehaviour
{
    public GameObject PoolBubble;
    public int PoolSize = 25;

    private Queue<GameObject> bubbleQueue;

    private void Start()
    {
        bubbleQueue = new Queue<GameObject>();
        for (int i = 0; i < PoolSize; i++)
        {
            GameObject poolBubble = Instantiate(PoolBubble, transform.position, Quaternion.identity);
            poolBubble.transform.SetParent(transform);
            bubbleQueue.Enqueue(poolBubble);
            poolBubble.SetActive(false);
        }
    }

    public GameObject GetBubbleFromPool(Vector2 position, Quaternion rotation)
    {
        GameObject poolBubble = bubbleQueue.Dequeue();
        poolBubble.transform.position = position;
        poolBubble.transform.rotation = rotation;
        bubbleQueue.Enqueue(poolBubble);
        return poolBubble;
    }
}