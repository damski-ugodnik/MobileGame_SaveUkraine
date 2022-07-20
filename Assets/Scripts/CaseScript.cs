using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaseScript : MonoBehaviour
{
    [SerializeField] private List<Texture> availableItems = new List<Texture>(1);
    [SerializeField] private int boxCapacity = 20;
    [SerializeField] private RawImage sample;
    [SerializeField] private float minSpinningSpeed = 1f, maxSpinningSpeed = 7f;
    private List<Texture> itemsInBox;



    private void Awake()
    {
        Debug.Log("Lessgo");
        RectTransform rTransform = GetComponent<RectTransform>();
        RawImage image;
        rTransform.sizeDelta = new Vector2(160 * boxCapacity, 90);
        for (int i = 0; i < boxCapacity; i++)
        {
            image = Instantiate(sample, transform);
            image.texture = availableItems[Random.Range(0, availableItems.Count)];
        }

        float speed = Random.Range(minSpinningSpeed, maxSpinningSpeed);
        StartCoroutine(Spin(speed));
    }

    private IEnumerator Spin(float speed)
    {
        
        while (speed > 0)
        {
            transform.position += Vector3.left*speed;
            speed -= Time.deltaTime;
            yield return null;
        }
    }

}

public class Item
{
    public string name;
    public Texture image;
}
