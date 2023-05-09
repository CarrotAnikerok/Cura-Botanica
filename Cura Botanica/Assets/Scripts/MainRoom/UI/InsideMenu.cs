using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneChanger;

public class InsideMenu : MonoBehaviour
{
    private CanvasGroup blackBackground;
    private Transform box;
    public Transition transition;

    /// <summary>
    /// ������ ������� ��������� ��������� ������� � �������, ������ ����������� ������ � 
    /// ������� ��� � ������, ����� ��� ��������� �������.
    /// </summary>
    private void OnEnable()
    {
        blackBackground = GameObject.Find("BlackBackground").GetComponent<CanvasGroup>();
        box = GameObject.Find("MenuWindow").GetComponent<Transform>();

        box.localPosition = new Vector2(-880f, 480f);
        box.localScale = Vector2.zero;
        blackBackground.alpha = 0; //�������� ������� ������� ���� �� ����

        box.LeanScale(Vector2.one, 0.2f);
        box.LeanMoveLocal(new Vector2(0f, 12f), 0.2f);
        blackBackground.LeanAlpha(1, 0.2f);
    }


    /// <summary>
    /// ��������� ������, ������� ��� � ������ ���� � ������ ����������.
    /// </summary>
    public void Close()
    {
        box.LeanScale(Vector2.zero, 0.2f);
        box.LeanMoveLocal(new Vector2(-880f, 480f), 0.2f);
        blackBackground.LeanAlpha(0, 0.2f).setOnComplete(OnComplete);

    }

    /// <summary>
    /// ���������� � ������� ����.
    /// </summary>
    public void TurnOnMenu()
    {
        transition.LoadMainMenu();
    }

    /// <summary>
    /// ������ ������ ����������.
    /// </summary>
    private void OnComplete()
    {
        gameObject.SetActive(false);
    }
}
