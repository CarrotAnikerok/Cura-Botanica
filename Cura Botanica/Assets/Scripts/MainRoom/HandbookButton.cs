using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class HandbookButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject handbook;
    public GameObject UI;
    public GameObject buttonImage;

    void Start()
    {
        UI = GameObject.Find("User Interface");
        buttonImage = GameObject.Find("Handbook Button Image");
        Debug.Log(handbook);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UI.SetActive(false);
        OpenHandbook();
        buttonImage.transform.LeanMoveLocal(new Vector2(15f, -10f), 0.3f).setEaseInOutCubic();
    }

    public void OpenHandbook()
    {
        handbook.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.transform.LeanMoveLocal(new Vector2(-25f, -10f), 0.3f).setEaseInOutCubic();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.transform.LeanMoveLocal(new Vector2(15f, -10f), 0.3f).setEaseInOutCubic();
    }
}
