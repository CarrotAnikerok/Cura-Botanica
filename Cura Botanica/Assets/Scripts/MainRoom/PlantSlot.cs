using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlantSlot : MonoBehaviour, IDropHandler
{
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
