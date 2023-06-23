using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PMHandbook : MonoBehaviour
{
    private GameObject handbookButton;
    private GameObject handbookImage;
    private GameObject plant;

    private TextMeshProUGUI title;
    private TextMeshProUGUI description;

    public void Awake()
    {
        handbookButton = GameObject.Find("PM Handbook Button");
        handbookImage = GameObject.Find("PM Handbook Image");
        plant = GameObject.Find("Actual Plant");

        title = GameObject.Find("PM Handbook Title").GetComponent<TextMeshProUGUI>();
        description = GameObject.Find("PM Handbook Description").GetComponent<TextMeshProUGUI>();
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

    public void getPlantDescription(string plantName) // у меня болит голова и завтра дедлайн, поэтому я делаю самый простой вариант заставить это работать. 
        // в идеале всю информацию по растениям было бы хорошо хранить в отдельном классе по ключам и обращаться к ней и отсюда, и из обычного справочника
    {
        switch (plantName)
        {
            case "Алое Вера":
                title.text = "Aloe Vera";
                description.text = "Требует очень много света, тогда как полив нужен достаточно умеренный. " +
                    "Как говорится, лучше пересушить, чем перелить! Влажность и температура нормальные. " +
                    "Для нормального функционирование удобрение не требуется.";
                break;
            case "Каланхоэ":
                title.text = "Kalanchoe";
                description.text = "Обычно растет без проблем, но быстро пересыхает. Нужно поливать умеренно и не переливать. " +
                    "Влажность и температура нормальные. Для нормального функционирование удобрение не требуется.";
                break;
            case "Кактус":
                title.text = "Кактус :D";
                description.text = "Это кактус, я его люблю <3";
                break;
        }
    }

}
