using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsAnimations : MonoBehaviour
{
    [SerializeField] private GameObject wateringAnim;
    [SerializeField] private GameObject sprayAnum;

    public void waterAnimation()
    {
        StartCoroutine(waterCoroutine());
    }

    public void StartWateringAnimation()
    {
        wateringAnim.SetActive(true);
        wateringAnim.GetComponent<Animator>().SetTrigger("Water");
    }

    public void EndtWateringAnimation()
    {
        wateringAnim.GetComponent<Animator>().SetTrigger("Base");
        wateringAnim.SetActive(false);
    }

    IEnumerator waterCoroutine()
    {
        StartWateringAnimation();
        yield return new WaitForSeconds(2.5f);
        EndtWateringAnimation();
    }


}
