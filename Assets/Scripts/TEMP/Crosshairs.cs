using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshairs : MonoBehaviour
{
    public GameObject lastCollision;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lastCollision = collision.gameObject;
    }
}
