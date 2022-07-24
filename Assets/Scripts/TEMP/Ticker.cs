using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    private AudioSource m_Audio;

    private void Awake()
    {
        m_Audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_Audio.Play();
    }
}
