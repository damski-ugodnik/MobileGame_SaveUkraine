using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DescrPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text titleText;
    [SerializeField] private RawImage image;

    public void Show(WeaponSerializable weapon)
    {
        gameObject.SetActive(true);
        titleText.text = weapon.name;
        image.texture = weapon.image.ActualTexture;
    }

    public void Suicide()
    {
        Destroy(this.gameObject);
    }

     
}
