using UnityEngine;
using UnityEngine.EventSystems;

public class DraggablePiece : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPosition;
    private Transform originalParent;
    private bool isCorrectPlace;

    public Transform slot;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        originalParent = transform.parent;
        transform.SetParent(transform.root); // Move to the root to avoid being hidden by other UI elements
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
        worldPoint.z = 0f;
        transform.position = worldPoint;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isCorrectPlace)
        {
            transform.position = slot.position;
            transform.SetParent(originalParent);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == slot)
        {
            isCorrectPlace = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == slot)
        {
            isCorrectPlace = false;
        }
    }
}