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
    public TextMeshProUGUI pastEveningField;

    [SerializeField] private int nodesCount;
    [SerializeField] private int eveningNodesCount;
    [SerializeField] private bool thereIsPhaseTitle;
    [SerializeField] private bool addAdditionalToEvening;



    [SerializeField] private GameObject[] panels = new GameObject[3];
    [SerializeField] private GameObject[] mainButtons = new GameObject[3];


    private void Awake()
    {
        panels[0] = info;
        panels[1] = notebook;
        panels[2] = description;
        nodesCount += 2;
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
        if (nodesCount >= 17 && thereIsPhaseTitle == false)
        {
            additionalField.transform.parent.gameObject.SetActive(true);
            additionalField.text += inscription + "\n";
            additionalField.transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0f, 34f);
            if (placeForNote == "Evening")
            {
                eveningNodesCount += 1;
                addAdditionalToEvening = true;
            }
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
                    eveningNodesCount += 1;
                    // PlayerPrefs.SetString("EveningNoteField", eveningField.text);
                    break;
            }
        }
        nodesCount += 1;
        Debug.Log("Nodes count " + nodesCount);
    }

    public void showNote(string notePhase)
    {
        if (nodesCount == 17)
        {
            Debug.Log("переход на след страницу");
            nodesCount = 0;
            switch (notePhase)
            {
                case "Morning":
                    startNewDay();
                    break;
                case "Day":
                    dayField.transform.parent.localPosition = new Vector2(340, 342);
                    dayField.transform.parent.gameObject.SetActive(true);
                    break;
                case "Evening":
                    eveningField.transform.parent.localPosition = new Vector2(340, 342);
                    eveningField.transform.parent.gameObject.SetActive(true);
                    eveningNodesCount += 2;
                    break;
            }
            thereIsPhaseTitle = true;
        } 
        else if (nodesCount > 17 && thereIsPhaseTitle == false)
        {
            nodesCount = nodesCount - 17;
            switch (notePhase)
            {
                case "Morning":
                    startNewDay();
                    break;
                case "Day":
                    calculateLocation(additionalField, dayField);
                    break;
                case "Evening":
                    calculateLocation(additionalField, eveningField);
                    eveningNodesCount += 2;
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
                    startNewDay();
                    break;
                case "Day":
                    calculateLocation(morningField, dayField);
                    break;
                case "Evening":
                    calculateLocation(dayField, eveningField);
                    eveningNodesCount += 2;
                    break;
            }
        }
        nodesCount += 2;
    }

    private void calculateLocation(TextMeshProUGUI pastField, TextMeshProUGUI newField)
    {
        float height = pastField.transform.parent.GetComponent<RectTransform>().sizeDelta.y;
        float border = pastField.transform.parent.localPosition.y + 50 - height / 2;
        newField.transform.parent.localPosition = new Vector2(pastField.transform.parent.localPosition.x, border - 100);
        newField.transform.parent.gameObject.SetActive(true);
    }

    private void startNewDay()
    {
        //clear notes
        additionalField.text = "";
        morningField.text = "«десь по€вл€ютс€ заметки за утро...\n";
        dayField.text = "«десь по€вл€ютс€ заметки за день...\n";

        pastEveningField.transform.parent.GetComponent<RectTransform>().sizeDelta
            = eveningField.transform.parent.GetComponent<RectTransform>().sizeDelta;

        morningField.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(588f, 100);
        dayField.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(588f, 100);
        eveningField.transform.parent.GetComponent<RectTransform>().sizeDelta = new Vector2(588f, 100);

        pastEveningField.text = eveningField.text;
        pastEveningField.text = pastEveningField.text.Substring(36);
        pastEveningField.text = "«десь наход€тс€ заметки за прошлый вечер..." + pastEveningField.text;
        eveningField.text = "«десь по€вл€ютс€ заметки за вечер...\n";

        if (addAdditionalToEvening == true)
        {
            pastEveningField.text += additionalField.text;
            addAdditionalToEvening = false;
        }

        additionalField.transform.parent.gameObject.SetActive(false);
        dayField.transform.parent.gameObject.SetActive(false);
        eveningField.transform.parent.gameObject.SetActive(false);

        pastEveningField.transform.parent.gameObject.SetActive(true);

        calculateLocation(pastEveningField, morningField);

        thereIsPhaseTitle = false;
        nodesCount = eveningNodesCount;
        eveningNodesCount = 0;
    }
}
