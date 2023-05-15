using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackTransition : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void StartTransition()
    {
        gameObject.SetActive(true);
        animator.SetTrigger("Start");
    }

    public IEnumerator FadeTransition()
    {
        animator.SetTrigger("Fade");
        yield return new WaitForSeconds(0.7f);
        gameObject.SetActive(false);
    }
}
