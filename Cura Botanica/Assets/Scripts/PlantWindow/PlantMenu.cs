using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlantMenu : MonoBehaviour
{
    private GameObject _plantButton;
    private GameObject _UI;
    private Vector2 _plantButtonPosition;
    private Tools _tools;
    private int stateOfPlant;

    public Image plantImage;
    public Sprite bigSprite;
    public Plant activePlant;
    public CanvasGroup blackBackground;
    public GameObject plantMenuContainer;
    public Image state;
    public Sprite[] states = new Sprite[6];


    private void Start()
    {
        state = GameObject.Find("State Image").GetComponent<Image>();
        plantMenuContainer = GameObject.Find("Plant Menu Container");
        _UI = GameObject.Find("User Interface");
        plantImage = GameObject.Find("Actual Image Of Plant").GetComponent<Image>();
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
            blackBackground = GameObject.Find("Black Background Plant").GetComponent<CanvasGroup>();

            // Находим объект, над которым нужно проводить операции
            activePlant = _plantButton.GetComponent<PlantButton>().plant;
            _tools.activePlant = activePlant;
            //Debug.Log("Это вызов из PlantMenu: " + activePlant.name);

            stateOfPlant = Array.FindIndex(activePlant.states, x => x == activePlant.state);

            // Меняем картинку на нужное растение
            bigSprite = activePlant.statesPicturesBig[stateOfPlant];
            plantImage.sprite = bigSprite;
            //bigImage = _plantButton.GetComponent<Image>();
            //plantImage.sprite = bigImage.sprite;

            // Значок состояния
            state.sprite = states[stateOfPlant];


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
