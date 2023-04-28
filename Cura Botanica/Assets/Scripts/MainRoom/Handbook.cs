using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Handbook : MonoBehaviour
{
    public GameObject UI;
    public CanvasGroup blackBG;

    public void OnEnable()
    {
        //blackBG = GameObject.Find("Black Background Handbook").GetComponent<CanvasGroup>();

        blackBG.gameObject.SetActive(true);
        //анимация
        transform.localPosition = new Vector2(1920f, 0f);
        blackBG.alpha = 0;

        transform.LeanMoveLocal(Vector2.zero, 0.4f).setEaseInOutCubic();
        blackBG.LeanAlpha(1, 0.4f);
    }

    public void Close()
    {
        blackBG.LeanAlpha(0, 0.4f);
        transform.LeanMoveLocal(new Vector2(1920f, 0f), 0.4f).setEaseInOutCubic().setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        gameObject.SetActive(false);
        blackBG.gameObject.SetActive(false);
        UI.SetActive(true);
    }
}
