using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantMenu : MonoBehaviour
{
    private GameObject plantButton;
    public Image plantImage;
    public Image buttonImage;
    public Plant activePlant;

    private void Start()
    {
        plantImage = GameObject.Find("ActualImageOfPlant").GetComponent<Image>();
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
            // ������ �������� �� ������ ��������
            plantButton = GameObject.Find("ActivePlantButton");
            buttonImage = plantButton.GetComponent<Image>();
            plantImage.sprite = buttonImage.sprite;

            // ������� ������, ��� ������� ����� ��������� ��������
            activePlant = plantButton.GetComponent<AloeVera>().aloeVera;

            transform.localScale = Vector2.zero;
            transform.localPosition = plantButton.transform.localPosition;

            transform.LeanScale(Vector2.one, 0.3f);
            transform.LeanMoveLocal(Vector2.zero, 0.3f);
        }

    }

    /// <summary>
    /// ��������� ������, ������� ��� � ������ � ������ ����������.
    /// </summary>
    public void Close()
    {
        transform.LeanMoveLocal(plantButton.transform.localPosition, 0.3f);
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
