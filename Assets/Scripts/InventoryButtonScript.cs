using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class InventoryButtonScript : MonoBehaviour
{
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private RawImage img;
    [SerializeField] DescrPanel descrPanel;
    private WeaponSerializable weapon;
    private InventoryFiller inventoryFiller;

    public void InitializeButton(WeaponSerializable w)
    {
        weapon = w;
        img.texture = weapon.image.ActualTexture;
    }

    private void Awake()
    {
        inventoryFiller = GetComponentInParent<InventoryFiller>();
    }

    void Update()
    {
        timeText.text = TimeLeft;
        GoodsHolder.CheckForExpired();
    }

    private string TimeLeft
    {
        get
        {
            TimeSpan ts = weapon.momentWhenDissapears - DateTime.Now;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", ts.Hours, ts.Minutes, ts.Seconds);
        }
    }

    public void ShowDescription()
    {
        Instantiate(descrPanel,inventoryFiller.transform.parent.parent.parent).Show(weapon);
    }
}
