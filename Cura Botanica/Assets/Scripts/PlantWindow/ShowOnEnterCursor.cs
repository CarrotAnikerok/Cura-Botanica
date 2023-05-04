using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShowOnEnterCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject minor;
    CanvasGroup minorCanvasGroup;

    public void Start()
    {
        minorCanvasGroup = minor.GetComponent<CanvasGroup>();
        minorCanvasGroup.alpha = 0;
        minor.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        minor.SetActive(true);
        minorCanvasGroup.LeanAlpha(1, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        minorCanvasGroup.LeanAlpha(0, 0.2f).setOnComplete(OnComplete);
    }

    private void OnComplete()
    {
        minor.SetActive(false);
    }
}
