using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GoodsHolder
{
    public static List<Item> lastItem;
    private static int killedSepars;
    public static int separsPerSecond = 1;

    public static int KilledSepars
    {
        get
        {
            return killedSepars = (int)(separsPerSecond * Time.realtimeSinceStartup);
        }
    }
}
