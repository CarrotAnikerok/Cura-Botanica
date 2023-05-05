using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SceneChanger;

public class MainMenu : MonoBehaviour
{
    public Transition transition;
    
    public void PlayGame() {
        transition.LoadNextScene();
    }

    public void QuitGame() {
        Debug.Log("Game has closed");
        Application.Quit();
    }
}
