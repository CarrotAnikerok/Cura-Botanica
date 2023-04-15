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
    /// ������� ������, �� ������� ������ ������ ����, � ����� �� ��������. ������ ������� ��������� ��������� ������� � �������, 
    /// ������ ����������� ������ � ������� ��� � ������, ����� ��� ��������� �������.
    /// </summary>
    private void OnEnable()
    {
        if (GameObject.Find("ActivePlantButton") != null)
        {
            plantButton = GameObject.Find("ActivePlantButton"); //������� ������� ������
            plantButtonPosition = plantButton.transform.position;

            // ������ �������� �� ������ ��������
            buttonImage = plantButton.GetComponent<Image>();
            plantImage.sprite = buttonImage.sprite;

            // ������� ������, ��� ������� ����� ��������� ��������
            activePlant = plantButton.GetComponent<PlantButton>().plant;
            tools.activePlant = activePlant;
            //Debug.Log("��� ����� �� PlantMenu: " + activePlant.name);

            // ��������
            transform.localScale = Vector2.zero;
            transform.position = plantButtonPosition;
            Debug.Log("��� ������� ��������" + transform.position);

            transform.LeanScale(Vector2.one, 0.3f);
            transform.LeanMoveLocal(Vector2.zero, 0.3f);
        }

    }

    /// <summary>
    /// ��������� ������, ������� ��� � ������ � ������ ����������.
    /// </summary>
    public void Close()
    {
        transform.LeanMove(plantButtonPosition, 0.3f);
        Debug.Log("��� ������� ��������" + transform.position);
        transform.LeanScale(Vector2.zero, 0.3f).setOnComplete(OnComplete);
    }

    /// <summary>
    /// ������ ������ ����������.
    /// </summary>
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
