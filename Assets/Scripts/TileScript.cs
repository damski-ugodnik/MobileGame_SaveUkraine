using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    private RectTransform m_RectTransform;
    private BoxCollider2D m_Collider;
    private AudioSource m_AudioSource;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_Collider = GetComponent<BoxCollider2D>();
        m_Collider.size = m_RectTransform.sizeDelta;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
