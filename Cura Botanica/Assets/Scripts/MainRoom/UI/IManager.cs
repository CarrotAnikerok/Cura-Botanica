using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IManager : MonoBehaviour
{
    public GameObject plantMenu;

    // Start is called before the first frame update
    void Awake()
    {
        plantMenu = GameObject.Find("PlantMenu");
        Debug.Log(plantMenu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
