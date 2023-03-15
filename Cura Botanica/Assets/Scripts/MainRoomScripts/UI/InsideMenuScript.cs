using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InsideMenuScript: MonoBehaviour
{
    public CanvasGroup blackBackground;
    public Transform box;

    private void OnEnable()
    {
        blackBackground = GameObject.Find("BlackBackground").GetComponent<CanvasGroup>();
        box = GameObject.Find("MenuWindow").GetComponent<Transform>();

        box.localPosition = new Vector2(-880f, 480f);
        box.localScale = Vector2.zero;
        blackBackground.alpha = 0;

        box.LeanScale(Vector2.one, 0.2f);
        box.LeanMoveLocal(new Vector2(0f, 12f), 0.2f);
        blackBackground.LeanAlpha(1, 0.2f);
    }

    public void TurnOnMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Close()
    {
        box.LeanScale(Vector2.zero, 0.2f);
        box.LeanMoveLocal(new Vector2(-880f, 480f), 0.2f);
        blackBackground.LeanAlpha(0, 0.2f).setOnComplete(OnComplete);

    }

    void OnComplete()
    {
        gameObject.SetActive(false);
    }

}
