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
            Debug.Log("Plant " + dropped.GetComponent<PlantButton>().plant.plantName + " was dropped in " + placeIndex + " slot.");
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            Debug.Log("Plant " + dropped.GetComponent<PlantButton>().plant.plantName + " has type of: " + transform.GetType());
            draggableItem.parentAfteDrag = transform;
        }
    }
}
