using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenu : MonoBehaviour
{
    private GameObject _plantButton;
    private GameObject _UI;
    private Vector2 _plantButtonPosition;
    private Tools _tools;

    public Image plantImage;
    public Image buttonImage;
    public Plant activePlant;
    public CanvasGroup blackBackground;
    public GameObject plantMenuContainer;


    private void Start()
    {
        plantMenuContainer = GameObject.Find("PlantMenuContainer");
        _UI = GameObject.Find("User Interface");
        plantImage = GameObject.Find("ActualImageOfPlant").GetComponent<Image>();
        _tools = plantMenuContainer.GetComponent<Tools>();
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
            _plantButton = GameObject.Find("ActivePlantButton"); //Находим нажатую кнопку
            _plantButtonPosition = _plantButton.transform.position;
            blackBackground = GameObject.Find("BlackBackgroundPlant").GetComponent<CanvasGroup>();

            // Меняем картинку на нужное растение
            buttonImage = _plantButton.GetComponent<Image>();
            plantImage.sprite = buttonImage.sprite;

            // Находим объект, над которым нужно проводить операции
            activePlant = _plantButton.GetComponent<PlantButton>().plant;
            _tools.activePlant = activePlant;
            //Debug.Log("Это вызов из PlantMenu: " + activePlant.name);

            // Анимации
            plantMenuContainer.transform.localScale = Vector2.zero;
            plantMenuContainer.transform.position = _plantButtonPosition;
            Debug.Log("Это позиция открытия" + transform.position);
            blackBackground.alpha = 0;

            plantMenuContainer.transform.LeanScale(Vector2.one, 0.3f);
            plantMenuContainer.transform.LeanMoveLocal(Vector2.zero, 0.3f);
            blackBackground.LeanAlpha(1, 0.2f);
        }

    }

    /// <summary>
    /// Уменьшает объект, двигает его к кнопке и делает неактивным.
    /// </summary>
    public void Close()
    {
        plantMenuContainer.transform.LeanMove(_plantButtonPosition, 0.3f);
        Debug.Log("Это позиция закрытия" + plantMenuContainer.transform.position);
        blackBackground.LeanAlpha(0, 0.2f);

        plantMenuContainer.transform.LeanScale(Vector2.zero, 0.3f).setOnComplete(OnComplete);
        _UI.SetActive(true);
    }

    /// <summary>
    /// Делает объект неактивным.
    /// </summary>
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
