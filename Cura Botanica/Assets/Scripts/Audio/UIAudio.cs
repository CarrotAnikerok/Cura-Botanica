using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    public void PlayGeneralClick() {
        FindObjectOfType<AudioManager>().Play("GeneralClick");
    }

    public void PlaySlideClick() {
        FindObjectOfType<AudioManager>().Play("SlideClick");
    }

    public void PlaySlide() {
        FindObjectOfType<AudioManager>().Play("SlideWindow");
    }

    public void PlayWhoosh() {
        FindObjectOfType<AudioManager>().Play("Whoosh");
    }
}
