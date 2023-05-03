using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlantSlot : MonoBehaviour, IDropHandler
{
    public Image image;
    public GameObject plantChild;

    private void Start()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            Debug.Log("Ёлемент упал" + dropped);
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfteDrag = transform;
        }
    }
}
