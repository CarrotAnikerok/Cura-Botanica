using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenu : MonoBehaviour
{
    private GameObject plantButton;
    private Vector2 plantButtonPosition;
    public Image plantImage;
    public Image buttonImage;
    public Plant activePlant;
    private Tools tools;

    private void Start()
    {
        plantImage = GameObject.Find("ActualImageOfPlant").GetComponent<Image>();
        tools = GetComponent<Tools>();
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Находит кнопку, из которой должно влезти меню, и берет ее картинку. Задает объекту начальные параметры размера и позиции, 
    /// дальше увеличивает объект и двигает его к центру, делая его полностью видимым.
    /// </summary>
    private void OnEnable()
    {
        if (GameObject.Find("ActivePlantButton") != null)
        {
            plantButton = GameObject.Find("ActivePlantButton"); //Находим нажатую кнопку
            plantButtonPosition = plantButton.transform.position;

            // Меняем картинку на нужное растение
            buttonImage = plantButton.GetComponent<Image>();
            plantImage.sprite = buttonImage.sprite;

            // Находим объект, над которым нужно проводить операции
            activePlant = plantButton.GetComponent<PlantButton>().plant;
            tools.activePlant = activePlant;
            //Debug.Log("Это вызов из PlantMenu: " + activePlant.name);

            // Анимации
            transform.localScale = Vector2.zero;
            transform.position = plantButtonPosition;
            Debug.Log("Это позиция открытия" + transform.position);

            transform.LeanScale(Vector2.one, 0.3f);
            transform.LeanMoveLocal(Vector2.zero, 0.3f);
        }

    }

    /// <summary>
    /// Уменьшает объект, двигает его к кнопке и делает неактивным.
    /// </summary>
    public void Close()
    {
        transform.LeanMove(plantButtonPosition, 0.3f);
        Debug.Log("Это позиция закрытия" + transform.position);
        transform.LeanScale(Vector2.zero, 0.3f).setOnComplete(OnComplete);
    }

    /// <summary>
    /// Делает объект неактивным.
    /// </summary>
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
