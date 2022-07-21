using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InventoryFiller : MonoBehaviour
{
    [SerializeField] private InventoryTile tileSample;

    void Start()
    {
        foreach (ObservableCollection<Item> col in GoodsHolder.Items)
            Instantiate(tileSample, transform).InitializeTile(col);
    }


}
