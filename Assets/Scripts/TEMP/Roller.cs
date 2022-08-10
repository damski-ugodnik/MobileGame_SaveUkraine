using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Roller : MonoBehaviour
{
    [SerializeField] private float maxSpeed, minSpeed;
    [SerializeField] private int boxCapacity = 200;
    [SerializeField] private Crosshairs crosshairs;
    [SerializeField] private ResultingPanel resulting;
    [SerializeField] private GameObject parentPanel;
    [SerializeField] private DescrPanel descrPanel;
    private List<Weapon> items = new List<Weapon>();
    private RectTransform m_RectTransform;
    private Vector3 startPosition;
    private bool IsRolling = false;

    private void Awake()
    {
        m_RectTransform = GetComponent<RectTransform>();
        m_RectTransform.sizeDelta = new Vector2(boxCapacity * 90, 60);
        startPosition = transform.localPosition;
    } 

    public void InitializeCase(Crate crate)
    {
        Weapon tmp;
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
        if (IsRolling)
        {
            return;
        }
        IsRolling = true;
        parentPanel.SetActive(true);
        new WaitForSeconds(5);
        Debug.Log("start spin");
        StartCoroutine(Spin(Random.Range(minSpeed, maxSpeed)));
    }

    private IEnumerator Spin(float speed)
    {
        Debug.Log(speed);
        while(speed > 0)
        {
            GetComponent<RectTransform>().localPosition += Vector3.left * speed*200*Time.deltaTime;
            speed -= Time.deltaTime;
            yield return null;
        }
        speed = 0;
        if(speed == 0)
        {
            DefinePrize();
            IsRolling = false;
            yield break;
        }
    }

    private void DefinePrize()
    {
        Weapon weapon = crosshairs.lastCollision.GetComponent<Weapon>();
        resulting.Claim(weapon);
        descrPanel.Show(weapon.WeaponSerializable);
    }
}
