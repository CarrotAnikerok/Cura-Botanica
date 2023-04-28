using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfteDrag;
    private PlantSlot[] objects;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfteDrag = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        image.raycastTarget = false;



        objects = FindObjectsOfType<PlantSlot>();
        foreach (PlantSlot obj in objects)
        {
            Debug.Log(obj);
            obj.image.enabled = true;
            if (obj.transform.childCount == 1)
            {
                obj.image.enabled = false;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("End drug");
        transform.SetParent(parentAfteDrag);
        image.raycastTarget = true;
        foreach (PlantSlot obj in objects)
        {
            Debug.Log(obj);
            obj.image.enabled = false;
        }
    }
}
