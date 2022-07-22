using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roller : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f, minSpeed = 1f;
    [SerializeField] private int boxCapacity = 200;
    [SerializeField] private List<Item> available;
    [SerializeField] private Crosshairs crosshairs;
    [SerializeField] private ResultingPanel resulting;
    private List<Item> items = new List<Item>();
    private RectTransform m_RectTransform;
    
    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_RectTransform.sizeDelta = new Vector2(boxCapacity * 90, 60);
        for(int i = 0; i < boxCapacity; i++)
        {
            items.Add(Instantiate(available[Random.Range(0, available.Count )], transform));
        }
        Open();
    }

    private void Open()
    {
        new WaitForSeconds(5);
        StartCoroutine(Spin(Random.Range(minSpeed, maxSpeed)));
    }

    private IEnumerator Spin(float speed)
    {
        while(speed > 0)
        {
            GetComponent<RectTransform>().localPosition += Vector3.left * speed;
            speed -= Time.deltaTime;
            yield return null;
        }
        DefinePrize();
    }

    private void DefinePrize()
    {
        resulting.Show(crosshairs.lastCollision.GetComponent<Item>());
    }
}
