using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May be used to call SaveSystem methods in Unity editor 
public class SaveManager : MonoBehaviour
{
    public void SaveSpecialPlant()
    {
        SaveSystem.SaveSpecialPlant(GameObject.FindObjectOfType<SpecialPlant>());
    }
}
