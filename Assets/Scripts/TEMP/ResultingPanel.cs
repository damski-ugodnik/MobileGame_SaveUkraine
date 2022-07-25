using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ResultingPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text descriptionText;
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private RawImage image;
    [SerializeField] private GameObject CaseChoicePanel;
    [SerializeField] private GameObject parentPanel;
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
        GoodsHolder.AddItem(claimedItem);
        gameObject.SetActive(false);
        parentPanel.SetActive(false);
        CaseChoicePanel.SetActive(true);
        CaseChoicePanel.GetComponentInChildren<DescriptionPanel>().RebootCrate();
    }

}
