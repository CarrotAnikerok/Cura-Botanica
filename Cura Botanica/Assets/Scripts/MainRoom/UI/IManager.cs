using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour

    // Класс нужен, чтобы изначально найти необходимые объекты и обращаться к ним через IManager,
    // даже если они недоступны
{
    public GameObject plantMenu;
    public string fase;

    void Awake()
    {
        plantMenu = GameObject.Find("PlantMenu");
    }
}
