using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantMenu : MonoBehaviour
{
    private GameObject plantButton1;

    /// <summary>
    /// ������ ������� ��������� ��������� ������� � �������, ������ ����������� ������ � 
    /// ������� ��� � ������, ����� ��� ��������� �������.
    /// </summary>
    private void OnEnable()
    {
        plantButton1 = GameObject.Find("PlantButton1");

        transform.localScale = Vector2.zero;
        transform.localPosition = plantButton1.transform.localPosition;

        transform.LeanScale(Vector2.one, 0.3f);
        transform.LeanMoveLocal(Vector2.zero, 0.3f);
    }

    /// <summary>
    /// ��������� ������, ������� ��� � ������ ���� � ������ ����������.
    /// </summary>
    private void Close()
    {
        transform.LeanMoveLocal(plantButton1.transform.localPosition, 0.3f);
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
