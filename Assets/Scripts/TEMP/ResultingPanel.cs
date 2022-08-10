using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ResultingPanel : MonoBehaviour
{
    public void Claim(Weapon prize)
    {
        Debug.Log("Collected");
        GoodsHolder.AddItem(prize);
        InventoryFiller.Instance.ShowInventory();
    }
}
