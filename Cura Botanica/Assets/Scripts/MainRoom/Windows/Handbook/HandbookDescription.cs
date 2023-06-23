using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class HandbookDescription : MonoBehaviour
{
    [SerializeField] private Sprite[] plantDrawings = new Sprite[2];
    string[] title = {"Aloe Vera", "Kalanchoe"};
    private string[] description =
        {"Алое вера - это бесстебельный или с коротким стеблем суккулент. Цвет Алое пёстрый, с вкраплением зеленых оттенков и пятен, " +
            "или полностью зеленый. Лист треугольный, вытянутый и мясистый, его края зубчатые. Стебель травянистый, укороченный. " +
            "Иногда может порадовать пышным соцветием, состоящим из цветов красного и желтого цвета. Издавна Алое используется в " +
            "медицине для лечения кожных заболеваний. Помимо этого, используется для парфюмерии и принимается в пищу.",
            "Каланхоэ - это толстянковый суккулент. Это растение отличается плотными зелеными округлыми листьями с зубчатыми краями. " +
            "Цветет Каланхоэ собранными в верхушечные соцветия-кисти с цветками до 1 сантиметра в диаметре. Считается, что данная культура " +
            "обладает свойством очищать воздух в помещении, уничтожая вредоносные бактерии. Кроме того, растение придает своему владельцам " +
            "прилив сил и бодрости, помогая проснуться."
    };
    string[] practicalPart = 
        {"Требует очень много света, тогда как полив нужен достаточно умеренный. " +
         "Как говорится, лучше пересушить, чем перелить! Влажность и температура нормальные. Для нормального функционирование удобрение не требуется.",
        "Обычно растет без проблем, но быстро пересыхает. Нужно поливать умеренно и не переливать. " +
        "Влажность и температура нормальные. Для нормального функционирование удобрение не требуется."
    };

    [SerializeField] private Image drawing;
    [SerializeField] private GameObject text;
    [SerializeField] private TextMeshProUGUI[] textComponents;

    private void Start()
    {
        textComponents = new TextMeshProUGUI[text.transform.childCount];
        for (int i = 0; i < text.transform.childCount; i++)
        {
            textComponents[i] = text.transform.GetChild(i).gameObject.GetComponent<TextMeshProUGUI>();
        }

        textComponents[0].text = title[0];
        textComponents[1].text = description[0];
        textComponents[2].text = practicalPart[0];
        drawing.sprite = plantDrawings[0];
    }

    public void MoveForward()
    {
        int i = Array.FindIndex(title, x => x == textComponents[0].text);
        if (i + 1 == title.Length)
        {
            textComponents[0].text = title[0];
            textComponents[1].text = description[0];
            textComponents[2].text = practicalPart[0];
            drawing.sprite = plantDrawings[0];
        }
        else
        {
            textComponents[0].text = title[i + 1];
            textComponents[1].text = description[i + 1];
            textComponents[2].text = practicalPart[i + 1];
            drawing.sprite = plantDrawings[i + 1];
        }
    }

    public void MoveBackward()
    {
        int i = Array.FindIndex(title, x => x == textComponents[0].text);
        if (i  == 0)
        {
            textComponents[0].text = title[title.Length - 1];
            textComponents[1].text = description[title.Length - 1];
            textComponents[2].text = practicalPart[title.Length - 1];
            drawing.sprite = plantDrawings[title.Length - 1];
        }
        else
        {
            textComponents[0].text = title[i - 1];
            textComponents[1].text = description[i - 1];
            textComponents[2].text = practicalPart[i - 1];
            drawing.sprite = plantDrawings[i - 1];
        }
    }
}
