using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
   public void OnPointerEnter(PointerEventData eventData)
    {
        print($"Input system work on {this.name}!");
        transform.LeanRotateZ(180f, 0.2f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        print($"Input system NOT on {this.name}!");
        transform.LeanRotateZ(-180f, 0.2f);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
