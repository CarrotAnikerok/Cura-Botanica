using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Handbook : MonoBehaviour
{

    [SerializeField] private GameObject info;
    [SerializeField] private GameObject notebook;
    [SerializeField] private GameObject description;

    public TextMeshProUGUI textField;

    [SerializeField] private GameObject[] panels = new GameObject[3];
    [SerializeField] private GameObject[] mainButtons = new GameObject[3];


    private void Awake()
    {
        panels[0] = info;
        panels[1] = notebook;
        panels[2] = description;
    }

    public void openBook(GameObject book)
    {
        GameObject mainButton = mainButtons[Array.FindIndex(panels, x => x == book)];

        foreach (GameObject panel in panels)
        {
            panel.SetActive(false);
        }

        foreach (GameObject button in mainButtons)
        {
            button.LeanMoveLocalY(0, 0.2f);
            button.GetComponent<ButtonAnimations>().isOn = false;
        }

        mainButton.LeanMoveLocalY(20, 0.2f).setEaseInOutCubic();
        mainButton.GetComponent<ButtonAnimations>().isOn = true;

        book.SetActive(true);
    }

    public void makeANote(string inscription)
    {
        textField.text += inscription;
    }
}
