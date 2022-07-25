using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roller : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 10f, minSpeed = 7f;
    [SerializeField] private int boxCapacity = 200;
    [SerializeField] private Crosshairs crosshairs;
    [SerializeField] private ResultingPanel resulting;
    [SerializeField] private GameObject parentPanel;
    private List<Item> items = new List<Item>();
    private RectTransform m_RectTransform;
    private Vector3 startPosition;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_RectTransform.sizeDelta = new Vector2(boxCapacity * 90, 60);
        startPosition = transform.localPosition;
    } 

    public void InitializeCase(Crate crate)
    {
        Item tmp;
        transform.localPosition = startPosition;
        for (int i = 0; i < boxCapacity; i++)
        {
            tmp = Instantiate(crate.AvailableNomenclature[Random.Range(0, crate.AvailableNomenclature.Count)], transform);
            tmp.gameObject.isStatic = true;
            items.Add(tmp);
        }
    }

    public void Open()
    {
        parentPanel.SetActive(true);
        new WaitForSeconds(5);
        Debug.Log("start spin");
        StartCoroutine(Spin(Random.Range(minSpeed, maxSpeed)));
    }

    private IEnumerator Spin(float speed)
    {
        while(speed > 0)
        {
            GetComponent<RectTransform>().localPosition += Vector3.left * speed;
            speed -= Time.smoothDeltaTime;
            yield return null;
        }
        speed = 0;
        if(speed == 0)
        {
            DefinePrize(); 
            yield break;
        }
    }

    private void DefinePrize()
    {
        resulting.Show(crosshairs.lastCollision.GetComponent<Item>());
    }
}
