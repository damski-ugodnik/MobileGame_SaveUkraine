using System.Collections.ObjectModel;
using System;
using UnityEngine;

[Serializable]
public static class GoodsHolder
{
    public static ObservableCollection<ObservableCollection<Item>> Items = new ObservableCollection<ObservableCollection<Item>>();
    private static int killedSepars;
    private static int separsPerSecond = 1;

    public static int KilledSepars
    {
        get
        {
            return killedSepars = (int)(separsPerSecond * Time.realtimeSinceStartup);
        }
    }

    public static void AddItem(Item item)
    {
        foreach(ObservableCollection<Item> col in Items)
        {
            if (col[0].itemName == item.itemName)
            {
                col.Add(item);
                return;
            }
        }
        ObservableCollection<Item> tmp = new ObservableCollection<Item>();
        tmp.Add(item);
        Items.Add(tmp);
    }
}
