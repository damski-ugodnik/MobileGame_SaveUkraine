using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 0.5f;

    void Update()
    {
        transform.position += Vector3.down * movingSpeed * Time.deltaTime;
    }
}
