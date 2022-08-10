using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.ObjectModel;
using TMPro;


public class InventoryTile : MonoBehaviour
{
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemCount;
    [SerializeField] private RawImage itemImage;

    public void InitializeTile(ObservableCollection<Weapon> items)
    {
        //Weapon item = items[0];
        //itemName.text = item.ItemName;
        //itemCount.text = "x" + items.Count.ToString();
        //itemImage.texture = item.ItemImage;
    }
}
