using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //  public static MenuManager Instance;
 
    // void Awake(){
    //     Instance = this;
    // }
    public float transitionTime = 1f;
    public Transition transition;


    public void PlayGame() {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        StartCoroutine(transition.LoadScene(SceneManager.GetActiveScene().buildIndex + 1));

    }

    public void QuitGame() {
        Debug.Log("Game has closed");
        Application.Quit();
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
