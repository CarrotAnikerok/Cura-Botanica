using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMenu : MonoBehaviour
{
    private GameObject plantButton;

      private void Start()
    {
        gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Задает объекту начальные параметры размера и позиции, дальше увеличивает объект и 
    /// двигает его к центру, делая его полностью видимым.
    /// </summary>
    private void OnEnable()
    {
        plantButton = GameObject.Find("ActivePlantButton");

        transform.localScale = Vector2.zero;
        transform.localPosition = plantButton.transform.localPosition;

        transform.LeanScale(Vector2.one, 0.3f);
        transform.LeanMoveLocal(Vector2.zero, 0.3f);
    }

    /// <summary>
    /// Уменьшает объект, двигает его к кнопке меню и делает неактивным.
    /// </summary>
    public void Close()
    {
        transform.LeanMoveLocal(plantButton.transform.localPosition, 0.3f);
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
