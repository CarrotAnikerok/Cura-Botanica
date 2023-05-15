using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneChanger;

public class InsideMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup blackBackground;
    private Transform box;
    public Transition transition;

    private void OnEnable()
    {
        box = GameObject.Find("Menu Window").GetComponent<Transform>();

        box.localPosition = new Vector2(-880f, 480f);
        box.localScale = Vector2.zero;
        blackBackground.alpha = 0; 

        box.LeanScale(Vector2.one, 0.2f);
        box.LeanMoveLocal(new Vector2(0f, 12f), 0.2f);

        blackBackground.gameObject.SetActive(true);
        blackBackground.LeanAlpha(1, 0.2f);
    }


    public void Close()
    {
        box.LeanScale(Vector2.zero, 0.2f);
        box.LeanMoveLocal(new Vector2(-880f, 480f), 0.2f);
        blackBackground.LeanAlpha(0, 0.2f).setOnComplete(OnComplete);

    }

    public void TurnOnMenu()
    {
        transition.LoadMainMenu();
    }

    private void OnComplete()
    {
        blackBackground.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
