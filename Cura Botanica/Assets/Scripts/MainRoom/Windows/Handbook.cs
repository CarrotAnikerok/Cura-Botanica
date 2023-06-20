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

    public TextMeshProUGUI morningField;
    public TextMeshProUGUI dayField;


    public TextMeshProUGUI eveningField;

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

    public void makeNote(string inscription, string placeForNote)
    {
        switch (placeForNote)
        {
            case "Morning":
                morningField.text += inscription + "\n";
                morningField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 100);
                // PlayerPrefs.SetString("MorningNoteField", morningField.text);
                break;
            case "Day":
                dayField.text += inscription + "\n";
                dayField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 100);
                // PlayerPrefs.SetString("DayNoteField", dayField.text);

                break;
            case "Evening":
                eveningField.text += inscription + "\n";
                eveningField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 100);
                // PlayerPrefs.SetString("EveningNoteField", eveningField.text);
                break;
        }
    }

    public void showNote(string notePhase)
    {
        switch (notePhase)
        {
            case "Morning":
                break;
            case "Day":
                float morningHeight = morningField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
                float morningBorder = morningField.transform.parent.localPosition.y + 50 - morningHeight / 2;
                dayField.transform.parent.localPosition = new Vector3(-283.92f, morningBorder - 100);
                dayField.transform.parent.gameObject.SetActive(true);
                break;
            case "Evening":
                float dayHeight = dayField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
                float dayBorder = dayField.transform.parent.localPosition.y + 50 - dayHeight / 2;
                eveningField.transform.parent.localPosition = new Vector3(-283.92f, dayBorder - 100);
                eveningField.transform.parent.gameObject.SetActive(true);
                break;
        }
        // 200-(dayHeight-200)\2-3
    }
}
