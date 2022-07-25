using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    private Roller roller;

    private void Awake()
    {
        roller = GetComponentInChildren<Roller>();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Log()
    {
        Debug.Log("Okay");
    }
}
