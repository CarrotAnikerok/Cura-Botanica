using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handbook : MonoBehaviour
{
    public GameObject UI;

    public void Close()
    {
        gameObject.SetActive(false);
        UI.SetActive(true);
    }
}
