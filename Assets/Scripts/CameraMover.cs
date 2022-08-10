using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance { get; private set; }

    [SerializeField] float timeToMove = 1f;
    [SerializeField] public GameObject defaultPos;
    [SerializeField] UnityEvent ReturnedToDefault = new UnityEvent();

    private void Awake()
    {
        Instance = this;
    }

    public void ReturnToStart()
    {
        StartCoroutine(Move(defaultPos.transform.position, defaultPos.transform.rotation, ReturnedToDefault));
    }

    public void MoveToPoint(GameObject target, UnityEvent zoomEvent)
    {

        StartCoroutine(Move(target.transform.position,target.transform.rotation, zoomEvent));
    }

    private IEnumerator Move(Vector3 targetPosition,Quaternion targetRotation, UnityEvent zoomEvent)
    {
        Vector3 currentPos = transform.position;
        Quaternion currentRot = transform.rotation;
        float timeElapsed = 0;
        while(timeElapsed< timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPosition, timeElapsed/timeToMove);
            transform.rotation = Quaternion.Lerp(currentRot, targetRotation, timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
        transform.rotation = targetRotation;
        zoomEvent.Invoke();
    }

    public void Log()
    {
        Debug.Log("click");
    }
}
