using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioClick : MonoBehaviour
{
    public AudioSource soundPlayer;

    public void ClickSound()
    {
        soundPlayer.Play();
    }
}
