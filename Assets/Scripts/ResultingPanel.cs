using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultingPanel : MonoBehaviour
{
    [SerializeField] private Text descriptionText;
    [SerializeField] private Text titleText;
    [SerializeField] private RawImage image;
    private Item claimedItem;

    public void Show(Item prize)
    {
        gameObject.SetActive(true);
        titleText.text = prize.itemName;
        image.texture = prize.itemImage;
        claimedItem = prize;
    }

    public void Claim()
    {
        claimedItem.SaveMe();
        GoodsHolder.AddItem(claimedItem);
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }

}
