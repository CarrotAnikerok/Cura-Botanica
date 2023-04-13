using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    [HideInInspector] public Transform parentAfteDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Begin drag");
        parentAfteDrag = transform.parent;
        transform.SetParent(transform.parent.parent);
        transform.SetAsLastSibling();
        Debug.Log(parentAfteDrag);
        image.raycastTarget = false;
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
        Debug.Log(transform.parent);
        image.raycastTarget = true;
    }
}
