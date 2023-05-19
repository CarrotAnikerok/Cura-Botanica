using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideAnimation : MonoBehaviour
{
    public GameObject UI;
    public CanvasGroup blackBG;

    public Vector2 positionOn;
    public Vector2 positionOff;


    public void OnEnable()
    {
        blackBG.gameObject.SetActive(true);

        //анимация
        transform.localPosition = positionOff;
        blackBG.alpha = 0;

        transform.LeanMoveLocal(Vector2.zero, 0.4f).setEaseInOutCubic();
        blackBG.LeanAlpha(1, 0.4f);
    }

    public void Close()
    {
        blackBG.LeanAlpha(0, 0.4f);
        transform.LeanMoveLocal(positionOff, 0.4f).setEaseInOutCubic().setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        gameObject.SetActive(false);
        blackBG.gameObject.SetActive(false);
        UI.SetActive(true);
    }
}
