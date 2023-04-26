using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour
{

    public Animator transition;
    public Image image;
    public Sprite[] fases = new Sprite[3];

    public void Awake()
    {
        transition = GetComponent<Animator>();
        image = GameObject.Find("Transition Image").GetComponent<Image>();
        image.sprite = fases[2];
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
