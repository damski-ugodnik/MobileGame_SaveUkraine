using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;
using UnityEngine.UI;
 
public class Crate : MonoBehaviour
{
    [SerializeField] private List<Item> availableItems = new List<Item>();

    [SerializeField] private string crateName;
    [SerializeField] private string description;
    [SerializeField] private Sprite avatar;

    public string Name { get { return crateName; } }
    public string Description { get { return description; } }
    public Sprite Avatar { get { return avatar; } }

    public ReadOnlyCollection<Item> AvailableNomenclature { get { return availableItems.AsReadOnly(); } }

    private void Awake()
    {
        GetComponent<Image>().sprite = avatar;
    }
}
