using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[Serializable]
public class Item : MonoBehaviour
{
    [SerializeField] public string itemName;

    [SerializeField] public string itemDescription;

    [SerializeField] public Texture itemImage;

    [SerializeField] private string fileName;
}