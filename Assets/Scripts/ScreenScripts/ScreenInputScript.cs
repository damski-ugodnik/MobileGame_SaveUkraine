using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScreenInputScript : MonoBehaviour
{
    [SerializeField] float dist = 20f;
    [SerializeField] LayerMask mask = ~0;
    [SerializeField] UnityEvent<Vector2> OnScreenInput = new UnityEvent<Vector2>();
    [SerializeField] GameObject zoomTarget;
    private bool IsZoomed = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.touches[0].position);
            if (!IsZoomed) {
                CameraMover.Instance.MoveToPoint(zoomTarget);
            } 

            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit, dist, mask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject != gameObject)
                {
                    return;
                }
                Debug.Log("yes");
                OnScreenInput.Invoke(hit.textureCoord);
            }
        }
        else
        {
            Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);


            RaycastHit hit;

            if (Physics.Raycast(inputRay, out hit, dist, mask, QueryTriggerInteraction.Ignore))
            {
                if (hit.collider.gameObject != gameObject)
                {
                    return;
                }
                Debug.Log("yes");
                if (!IsZoomed&&Input.GetMouseButtonDown(0))
                {
                    CameraMover.Instance.MoveToPoint(zoomTarget);
                }
                OnScreenInput.Invoke(hit.textureCoord);
            }
        }
    }
}
