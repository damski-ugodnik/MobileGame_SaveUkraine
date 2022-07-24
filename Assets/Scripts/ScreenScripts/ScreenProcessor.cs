using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScreenProcessor : MonoBehaviour
{
    [SerializeField] RectTransform canvasTransform;

    GraphicRaycaster raycaster;

    private void Start()
    {
        raycaster = GetComponent<GraphicRaycaster>();
    }

    public void OnScreenInput(Vector2 normalisedPosition)
    {
        Vector3 position = new Vector3(canvasTransform.sizeDelta.x * normalisedPosition.x,
            canvasTransform.sizeDelta.y * normalisedPosition.y, 0f);
        PointerEventData pointerEvent = new PointerEventData(EventSystem.current);

        pointerEvent.position = position;
        List<RaycastResult> results = new List<RaycastResult>();

        raycaster.Raycast(pointerEvent, results);

        bool mouseDown = Input.GetMouseButtonDown(0);
        bool mouseUp = Input.GetMouseButtonUp(0);

        foreach(var result in results)
        {
            if (mouseDown)
            {
                ExecuteEvents.Execute(result.gameObject, pointerEvent, ExecuteEvents.pointerDownHandler);
            }else if (mouseUp)
            {
                ExecuteEvents.Execute(result.gameObject, pointerEvent, ExecuteEvents.pointerUpHandler);
                ExecuteEvents.Execute(result.gameObject, pointerEvent, ExecuteEvents.pointerClickHandler);
            }
        }
    }
}
