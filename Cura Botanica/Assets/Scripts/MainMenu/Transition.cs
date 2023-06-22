using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Used for starting animation between scenes.
*/
namespace SceneChanger
{
    public class Transition : MonoBehaviour
    {
        public Animator transition;

        public float transitionTime = 1f;

        public void LoadNextScene()
        {
            StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
            ArrangePlants();
        }

        private void ArrangePlants()
        {
            PlantButton[] savedPlants = SaveSystem.LoadPlants();
        }

        public void LoadMainMenu()
        {
            SaveSystem.SavePlants(FindObjectsOfType<PlantButton>());
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
