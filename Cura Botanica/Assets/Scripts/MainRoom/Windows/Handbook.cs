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

    public void makeNote(string inscription, int placeForNote)
    {
        switch (placeForNote)
        {
            case 0:
                morningField.text += inscription + "\n";
                morningField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 110);
                // PlayerPrefs.SetString("MorningNoteField", morningField.text);
                break;
            case 1:
                dayField.text += inscription + "\n";
                dayField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 110);
                // PlayerPrefs.SetString("DayNoteField", dayField.text);

                break;
            case 2:
                eveningField.text += inscription + "\n";
                eveningField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 110);
                // PlayerPrefs.SetString("EveningNoteField", eveningField.text);
                break;
        }
    }

    public void showNote(int notePhase)
    {
        switch (notePhase)
        {
            case 0:
                break;
            case 1:
                Vector2 height = morningField.transform.parent.GetComponent<RectTransform>().sizeDelta;
                dayField.transform.parent.localPosition += new Vector3(0f, 200-(height.y-200/2-3));
                dayField.transform.parent.gameObject.SetActive(true);
                break;
            case 2:
                eveningField.gameObject.SetActive(true);
                break;
        }
        // 200-(dayHeight-200)\2-3
    }
}
