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
    /// ������� ������, �� ������� ������ ������ ����, � ����� �� ��������. ������ ������� ��������� ��������� ������� � �������, 
    /// ������ ����������� ������ � ������� ��� � ������, ����� ��� ��������� �������.
    /// </summary>
    private void OnEnable()
    {
        if (GameObject.Find("ActivePlantButton") != null)
        {
            _plantButton = GameObject.Find("ActivePlantButton"); //������� ������� ������
            _plantButtonPosition = _plantButton.transform.position;
            blackBackground = GameObject.Find("BlackBackgroundPlant").GetComponent<CanvasGroup>();

            // ������ �������� �� ������ ��������
            buttonImage = _plantButton.GetComponent<Image>();
            plantImage.sprite = buttonImage.sprite;

            // ������� ������, ��� ������� ����� ��������� ��������
            activePlant = _plantButton.GetComponent<PlantButton>().plant;
            _tools.activePlant = activePlant;
            //Debug.Log("��� ����� �� PlantMenu: " + activePlant.name);

            // ��������
            plantMenuContainer.transform.localScale = Vector2.zero;
            plantMenuContainer.transform.position = _plantButtonPosition;
            Debug.Log("��� ������� ��������" + transform.position);
            blackBackground.alpha = 0;

            plantMenuContainer.transform.LeanScale(Vector2.one, 0.3f);
            plantMenuContainer.transform.LeanMoveLocal(Vector2.zero, 0.3f);
            blackBackground.LeanAlpha(1, 0.2f);
        }

    }

    /// <summary>
    /// ��������� ������, ������� ��� � ������ � ������ ����������.
    /// </summary>
    public void Close()
    {
        plantMenuContainer.transform.LeanMove(_plantButtonPosition, 0.3f);
        Debug.Log("��� ������� ��������" + plantMenuContainer.transform.position);
        blackBackground.LeanAlpha(0, 0.2f);

        plantMenuContainer.transform.LeanScale(Vector2.zero, 0.3f).setOnComplete(OnComplete);
        _UI.SetActive(true);
    }

    /// <summary>
    /// ������ ������ ����������.
    /// </summary>
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
