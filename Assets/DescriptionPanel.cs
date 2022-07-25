using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DescriptionPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text Name;
    [SerializeField] private TMP_Text Description;
    [SerializeField] private RawImage Avatar;
    [SerializeField] private Button Button;
    [SerializeField] private Roller roller;
    private Crate currentCrate;
    
    public void SetCase(Crate crate)
    {
        currentCrate = crate;
        Name.gameObject.SetActive(true);
        Description.gameObject.SetActive(true);
        Avatar.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
        Name.text = crate.Name;
        Description.text = crate.Description;
        Avatar.texture = crate.Avatar.texture;
        roller.InitializeCase(crate);
    }

    public void RebootCrate()
    {
        roller.InitializeCase(currentCrate);
    }
}
