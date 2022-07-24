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

    public void InitializeTile(ObservableCollection<Item> items)
    {
        Item item = items[0];
        itemName.text = item.itemName;
        itemCount.text = "x" + items.Count.ToString();
        itemImage.texture = item.itemImage;
    }
}
