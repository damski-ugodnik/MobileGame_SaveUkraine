using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    private WeaponSerializable weaponSerializable = new WeaponSerializable();

    public WeaponData WeaponData { get { return weaponData; } }

    public WeaponSerializable WeaponSerializable
    {
        get
        {
            weaponSerializable.momentWhenDissapears = DateTime.Now.AddHours(weaponData.HoursUntilDissapears);
            weaponSerializable.description = weaponData.WeaponDescription;
            weaponSerializable.name = weaponData.WeaponName;
            weaponSerializable.image.x = weaponData.WeaponImage.width;
            weaponSerializable.image.y = weaponData.WeaponImage.height;
            weaponSerializable.image.bytes = ImageConversion.EncodeToPNG(weaponData.WeaponImage);
            weaponSerializable.russiansPerSecond = weaponData.RussiansPerSecond;
            return weaponSerializable;
        }
    }

    public TimeSpan TimeLeft
    {
        get
        {
            return weaponSerializable.momentWhenDissapears.AddHours(weaponData.HoursUntilDissapears) - DateTime.Now;
        }
    }
}

[Serializable]
public class WeaponSerializable
{
    [SerializeField]
    public string name;
    [SerializeField]
    public string description;
    [SerializeField]
    public SerializableTexture image = new SerializableTexture();
    [SerializeField]
    public int russiansPerSecond;
    [SerializeField]
    public DateTime momentWhenDissapears;
}

[Serializable]
public class SerializableTexture
{
    [SerializeField]
    public int x;
    [SerializeField]
    public int y;
    [SerializeField]
    public byte[] bytes;

    public Texture2D ActualTexture
    {
        get
        {
            Texture2D texture = new Texture2D(x, y);
            ImageConversion.LoadImage(texture, bytes);
            return texture;
        }
    }
}
