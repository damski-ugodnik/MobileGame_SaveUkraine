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

    public void Show(Item prize)
    {
        gameObject.SetActive(true);
        titleText.text = prize.itemName;
        image.texture = prize.itemImage;
        //GoodsHolder.lastItem = prize;
    }

    public void Restart()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }

}
