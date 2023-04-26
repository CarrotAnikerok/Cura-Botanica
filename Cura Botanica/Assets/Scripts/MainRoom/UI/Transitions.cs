using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Transitions : MonoBehaviour
{

    public Animator transition;
    public Sprite[] fase = new Sprite[3];
    public Image image;
    public GameObject blockWindow;
    public void Awake()
    {
        transition = GetComponent<Animator>();
        image = GameObject.Find("Transition Image").GetComponent<Image>();
    }

    public void StartTransition()
    {
        blockWindow.SetActive(true);
        gameObject.SetActive(true);
        transition.SetTrigger("Start");
    }

    public void EndTransition()
    {
        transition.SetTrigger("Continue");
    }

    public void ReturnToStart()
    {
        blockWindow.SetActive(false);
        gameObject.SetActive(false);
        transition.SetTrigger("End");
    }
}
