using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collided");
        GetComponent<AudioSource>().Play();
    }
}
