using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class InventoryFiller : MonoBehaviour
{
    [SerializeField] private InventoryButtonScript tileSample;
    private List<InventoryButtonScript> children = new List<InventoryButtonScript> ();

    public static InventoryFiller Instance
    {
        get { return FindObjectOfType<InventoryFiller>(); }
    }

    public void ShowInventory()
    {
        foreach (InventoryButtonScript child in children)
        {
            Destroy (child.gameObject);
        }
        children.Clear ();
        InventoryButtonScript tmp;
        foreach (WeaponSerializable weapon in GoodsHolder.Weapons)
        {

            tmp = Instantiate(tileSample, transform);
            tmp.InitializeButton(weapon);
            children.Add(tmp);
        }
    }


}
