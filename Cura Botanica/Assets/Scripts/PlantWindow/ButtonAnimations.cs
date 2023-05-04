using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonAnimations : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    Image image;
    public bool needClick;

    void Start()
    {
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        image.color = new Color32(220, 220, 220, 255);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 255);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (needClick)
        {
            image.color = new Color32(160, 160, 160, 255);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (needClick)
        {
            image.color = new Color32(220, 220, 220, 255);
        }
    }

}
