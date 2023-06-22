using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WelcomeScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool showWelcomeScreen = !GameObject.FindObjectOfType<SpecialPlant>().isTuned; // Didn't understand how to get special plant field "isTuned"
        
        if (showWelcomeScreen)
        {
            gameObject.SetActive(false);
        } else
        {
            gameObject.SetActive(true);
        }
        
    }
}
