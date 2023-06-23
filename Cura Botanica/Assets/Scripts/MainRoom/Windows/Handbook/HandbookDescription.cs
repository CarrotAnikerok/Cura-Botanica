using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandbookDescription : MonoBehaviour
{
    [SerializeField] private Sprite[] plantDrawings = new Sprite[2];
    [SerializeField] private TextMeshProUGUI[] title = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI[] description = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI[] practicalPart = new TextMeshProUGUI[2];

    [SerializeField] private GameObject text;
    [SerializeField] private GameObject[] textComponents;

    private void Start()
    {
        textComponents = new GameObject[text.transform.childCount];
        for (int i = 0; i < text.transform.childCount; i++)
        {
            textComponents[i] = text.transform.GetChild(i).gameObject;
        }
    }


}
