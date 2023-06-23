using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using SaveManager;

/* Used for starting animation between scenes.
*/
namespace SceneChanger
{
    public class Transition : MonoBehaviour
    {
        public Animator transition;
        public SaveManager saveManager;

        public float transitionTime = 1f;

        public void LoadNextScene()
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
            // SaveSystem.LoadData(saveManager.specialPlant);
            // ArrangePlants();
        }

        public void LoadMainMenu()
        {
            // SaveSystem.SaveData();
            StartCoroutine(LoadScene(0));
        }

        public IEnumerator LoadScene(int sceneIndex)
        {
            transition.SetTrigger("Start");

            yield return new WaitForSeconds(transitionTime);

            SceneManager.LoadScene(sceneIndex);
        }
    }
}
