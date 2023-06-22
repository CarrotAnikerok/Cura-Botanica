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
            PlantSlot[] plantSlots = FindObjectsOfType<PlantSlot>();

            int[] usedSlots = new int[savedPlants.Length];
            for (int i = 0; i < savedPlants.Length; i++)
            {
                usedSlots[i] = savedPlants[i].placeIndex;
            }

            foreach (int slot in usedSlots)
            {
                foreach (PlantButton plant in savedPlants)
                {
                    plant.transform.SetParent(plantSlots[slot].transform);
                }
            }
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
