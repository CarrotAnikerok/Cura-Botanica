using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class HandbookButton : MonoBehaviour, IPointerClickHandler
{
    public GameObject handbook;
    public GameObject UI;

    void Start()
    {
        UI = GameObject.Find("User Interface");
        Debug.Log(handbook);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        UI.SetActive(false);
        OpenHandbook();
    }

    public void OpenHandbook()
    {
        handbook.SetActive(true);
    }
}
