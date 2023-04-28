using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PMHandbook : MonoBehaviour
{
    [SerializeField] GameObject handbookButton;
    [SerializeField] GameObject handbookImage;
    [SerializeField] GameObject plant;

    public void Awake()
    {
        handbookButton = GameObject.Find("PM Handbook Button");
        handbookImage = GameObject.Find("PM Handbook Image");
        plant = GameObject.Find("Actual Plant");
    }
    public void ToggleHandbook()
    {
        if (handbookImage.transform.localPosition.x == 0f)
        {
            CloseHandbook();
        }
        else
        {
            OpenHandbook();
        }
    }

    public void OpenHandbook()
    {
        handbookButton.transform.LeanMoveLocal(new Vector2(-500f, 0f), 0.5f).setEaseInOutCubic();
        handbookImage.transform.LeanMoveLocal(new Vector2(0f, 0f), 0.5f).setEaseInOutCubic();
        plant.transform.LeanMoveLocal(new Vector2(-400f, 63f), 0.5f).setEaseInOutCubic();
    }

    public void CloseHandbook()
    {
        handbookButton.transform.LeanMoveLocal(new Vector2(205f, 0f), 0.5f).setEaseInOutCubic();
        handbookImage.transform.LeanMoveLocal(new Vector2(702f, 0f), 0.5f).setEaseInOutCubic();
        plant.transform.LeanMoveLocal(new Vector2(0f, 63f), 0.5f).setEaseInOutCubic();
    }

}
