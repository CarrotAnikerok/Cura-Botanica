using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transitions : MonoBehaviour
{

    public Animator transition;

    public void Awake()
    {
        transition = GetComponent<Animator>();
    }

    public void StartTransition()
    {
        transition.SetTrigger("Start");
         
    }

    public void EndTransition()
    {
        transition.SetTrigger("Continue");
    }

    public void ReturnToStart()
    {
        gameObject.SetActive(false);
        transition.SetTrigger("End");
        gameObject.SetActive(true);
    }
}
