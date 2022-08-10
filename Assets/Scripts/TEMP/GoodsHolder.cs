using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using System.Collections;
using System.Threading.Tasks;

public static class GoodsHolder
{
    private static List<WeaponSerializable> Items;
    private static int killedSepars;
    private static int separsPerSecond = 1;

    public static IReadOnlyCollection<WeaponSerializable> Weapons
    {
        get
        {
            return Items.AsReadOnly();
        }
    }

    public static int KilledSepars
    {
        get
        {
            return killedSepars;
        }
    }

    public static int RussiansPerSecond
    {
        get
        {
            return separsPerSecond;
        }
    }

    private static void CalculateKillsPerSecond()
    {
        int res = 0;

        foreach (WeaponSerializable weapon in Items)
        {
            res += weapon.russiansPerSecond;

        }

        separsPerSecond = res;
    }

    public static void CheckForExpired()
    {
        for(int i =Items.Count-1; i>=0; i-- )
        {
            if (Items[i].momentWhenDissapears <= DateTime.Now)
            {
                Items.Remove(Items[i]);
                InventoryFiller.Instance.ShowInventory();
            }
        }

        CalculateKillsPerSecond();
    }

    public static void AddItem(Weapon item)
    {
        WeaponSerializable itemInfo = item.WeaponSerializable;
        Items.Add(itemInfo);
        CalculateKillsPerSecond();
        SaveInfo();
    }

    private static async void CountSepars()
    {
        DateTime startTime = DateTime.Now;
        TimeSpan time;
        while(Application.isPlaying)
        {
            time = DateTime.Now - startTime;
            if (time.Seconds>=1)
            {
                killedSepars+=separsPerSecond;
                Debug.Log("incr");
                startTime = DateTime.Now;
            }
            await Task.Yield();
        }
        SaveInfo();
        return;
        
    }

    private static void SaveInfo()
    {
        BinaryFormatter binary = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, "weapons.zsu");
        using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            binary.Serialize(fs, Items);
        }
        path = Path.Combine(Application.persistentDataPath, "losses.ork");
        using(FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
        {
            binary.Serialize(fs, killedSepars);
        }
    }

    [RuntimeInitializeOnLoadMethod]
    private static void LoadInfo()
    {
        //BinaryFormatter binary = new BinaryFormatter();
        //string path = Path.Combine(Application.persistentDataPath, "weapons.zsu");
        //if (File.Exists(path))
        //    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    {
        //        Items = binary.Deserialize(fs) as List<WeaponSerializable>;
        //    }
        //else
        //{
        //    Items = new List<WeaponSerializable>();
        //}
        //path = Path.Combine(Application.persistentDataPath, "losses.ork");
        //if (File.Exists(path))
        //    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    {
        //        killedSepars = (int)binary.Deserialize(fs);
        //        Debug.Log(killedSepars);
        //    }
        //else { killedSepars = 0; }
        //Debug.Log(killedSepars);
        //CheckForExpired();
        //InventoryFiller.Instance.ShowInventory();
        //CountSepars();
    }
    
}
