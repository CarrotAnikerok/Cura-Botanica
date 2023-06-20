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
    public TextMeshProUGUI additionalField;

    [SerializeField] private int nodesCount;
    [SerializeField] private bool thereIsPhaseTitle;


    [SerializeField] private GameObject[] panels = new GameObject[3];
    [SerializeField] private GameObject[] mainButtons = new GameObject[3];


    private void Awake()
    {
        panels[0] = info;
        panels[1] = notebook;
        panels[2] = description;
        nodesCount = 0;
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
        if (nodesCount >= 15 && thereIsPhaseTitle == false)
        {
            additionalField.gameObject.SetActive(true);
            additionalField.text += inscription + "\n";
            additionalField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 34f);
        }
        else
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

        nodesCount += 1;
        Debug.Log("Nodes count " + nodesCount);
    }

    public void showNote(string notePhase)
    {
        if (nodesCount == 15 && thereIsPhaseTitle == false)
        {
            Debug.Log("переход на след страницу");
            switch (notePhase)
            {
                case "Morning":
                    morningField.transform.parent.localPosition = new Vector2(340, 400);
                    morningField.transform.parent.gameObject.SetActive(true);
                    break;
                case "Day":
                    dayField.transform.parent.localPosition = new Vector2(340, 342);
                    dayField.transform.parent.gameObject.SetActive(true);
                    break;
                case "Evening":
                    eveningField.transform.parent.localPosition = new Vector2(340, 342);
                    eveningField.transform.parent.gameObject.SetActive(true);
                    break;
            }
            thereIsPhaseTitle = true;
        } 
        else if (nodesCount > 15 && thereIsPhaseTitle == false)
        {
            float additionalHeight = additionalField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
            float additionalBorder = additionalField.transform.parent.localPosition.y + 50 - additionalHeight / 2;
            Debug.Log("Additional height " + additionalHeight);
            Debug.Log("Additional border " + additionalBorder);
            Debug.Log("additionalField.transform.localPosition " + additionalField.transform.parent.localPosition);
            switch (notePhase)
            {
                case "Morning":
                    morningField.transform.parent.localPosition = new Vector2(additionalField.transform.parent.localPosition.x, additionalBorder - 100);
                    morningField.transform.parent.gameObject.SetActive(true);
                    break;
                case "Day":
                    dayField.transform.parent.localPosition = new Vector2(additionalField.transform.parent.localPosition.x, additionalBorder - 100);
                    dayField.transform.parent.gameObject.SetActive(true);
                    break;
                case "Evening":
                    eveningField.transform.parent.localPosition = new Vector2(additionalField.transform.parent.localPosition.x, additionalBorder - 100);
                    eveningField.transform.parent.gameObject.SetActive(true);
                    break;
            }
            thereIsPhaseTitle = true;
        }
        else
        {
            Debug.Log("перехода нет");
            switch (notePhase)
            {
                case "Morning":
                    break;
                case "Day":
                    float morningHeight = morningField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
                    float morningBorder = morningField.transform.parent.localPosition.y + 50 - morningHeight / 2;
                    dayField.transform.parent.localPosition = new Vector2(morningField.transform.parent.localPosition.x, morningBorder - 100);
                    dayField.transform.parent.gameObject.SetActive(true);
                    Debug.Log("Перехода нет " + dayField.transform.parent.localPosition);
                    Debug.Log("Перехода нет " + dayField.transform.parent.position);
                    break;
                case "Evening":
                    float dayHeight = dayField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
                    float dayBorder = dayField.transform.parent.localPosition.y + 50 - dayHeight / 2;
                    eveningField.transform.parent.localPosition = new Vector2(dayField.transform.parent.localPosition.x, dayBorder - 100);
                    eveningField.transform.parent.gameObject.SetActive(true);
                    Debug.Log("Перехода нет " + eveningField.transform.parent.localPosition);
                    Debug.Log("Перехода нет " + eveningField.transform.parent.position);
                    break;
            }
        }

        nodesCount += 2;
        // 200-(dayHeight-200)\2-3
    }
}
