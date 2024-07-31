using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class uiDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    public RectTransform figura1;
    private CanvasGroup canvasGroup;
    private Vector2 initialPosition;
    private Canvas canvas;
    public EndHorario calendar;


    [SerializeField] private string targetTag = "Target";

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();
        initialPosition = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;  // Permite que o objeto seja ignorado pelos raycasts enquanto arrasta
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;  // Reativa os raycasts após soltar o objeto

        GameObject targetObject = GetTargetUnderMouse();
        if (targetObject != null)
        {
            // Posiciona o objeto na mesma posição que o alvo
            rectTransform.anchoredPosition = figura1.anchoredPosition;
            calendar.count++;
            UIDraggable.Destroy(this);
        }
        else
        {
            // Retorna à posição inicial se não estiver sobre o alvo
            ReturnToInitialPosition();
        }
    }

    private void ReturnToInitialPosition()
    {
        rectTransform.anchoredPosition = initialPosition;
    }

    private GameObject GetTargetUnderMouse()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current)
        {
            position = Input.mousePosition
        };

        var results = new System.Collections.Generic.List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, results);

        foreach (var result in results)
        {
            if (result.gameObject.CompareTag(targetTag))
            {
                return result.gameObject;
            }
        }
        return null;
    }


}
