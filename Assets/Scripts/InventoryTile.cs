using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.ObjectModel;


public class InventoryTile : MonoBehaviour
{
    [SerializeField] private Text itemName;
    [SerializeField] private Text itemCount;
    [SerializeField] private RawImage itemImage;

    public void InitializeTile(ObservableCollection<Item> items)
    {
        Item item = items[0];
        itemName.text = item.itemName;
        itemCount.text = "x" + items.Count.ToString();
        itemImage.texture = item.itemImage;
    }
}
