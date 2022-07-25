using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public static CameraMover Instance { get; private set; }

    [SerializeField] float timeToMove = 1f;
    [SerializeField] public GameObject defaultPos;

    private void Awake()
    {
        Instance = this;
    }

    public void MoveToPoint(GameObject target)
    {

        StartCoroutine(Move(target.transform.position));
    }

    private IEnumerator Move(Vector3 targetPosition)
    {
        Vector3 currentPos = transform.position;
        float timeElapsed = 0;
        while(timeElapsed< timeToMove)
        {
            transform.position = Vector3.Lerp(currentPos, targetPosition, timeElapsed/timeToMove);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}
