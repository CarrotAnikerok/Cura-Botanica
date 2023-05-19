using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SideButton : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject window;
    private GameObject _UI;
    private Vector2 _normalPosition;
    public Vector2 onPointerPostion;

    void Start()
    {
        _UI = GameObject.Find("User Interface");
        _normalPosition = transform.localPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _UI.SetActive(false);
        OpenHandbook();
        transform.LeanMoveLocal(_normalPosition, 0.3f).setEaseInOutCubic();
    }

    public void OpenHandbook()
    {
        window.SetActive(true);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.LeanMoveLocal(onPointerPostion, 0.3f).setEaseInOutCubic();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.LeanMoveLocal(_normalPosition, 0.3f).setEaseInOutCubic();
    }
}
