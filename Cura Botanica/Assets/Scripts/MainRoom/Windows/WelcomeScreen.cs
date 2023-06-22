using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{

    [SerializeField] private SpecialPlant specialPlant;

    void Start()
    {  
        if (specialPlant.isTuned)
        {
            Debug.Log("Welcome screen doesnt open");
            gameObject.SetActive(false);
        } 
        else
        {
            Debug.Log("Welcome screen opens");
            gameObject.SetActive(true);
        }
        
    }
}
