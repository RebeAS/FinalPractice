using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleScript : MonoBehaviour
{
    private BubbleStats bubbleStats;
    private SoundManager soundManager;
    private Animator animator;
    private Collider2D myCollider2D;

    public float TimeToBust;

    private void Start()
    {
        bubbleStats = GetComponent<BubbleStats>();
        soundManager = FindObjectOfType<SoundManager>();
        animator = GetComponentInChildren<Animator>();
        myCollider2D = GetComponent<Collider2D>();

        bubbleStats.OnBust += Busted;
    }

    public void Busted()
    {
        StartCoroutine(Busting());
    }

    public IEnumerator Busting()
    {
        soundManager.BustingBubbles();
        animator.SetTrigger("IsBusted");
        myCollider2D.enabled = false;
        yield return new WaitForSeconds(TimeToBust);
        myCollider2D.enabled = true;
        gameObject.SetActive(false);
    }
}