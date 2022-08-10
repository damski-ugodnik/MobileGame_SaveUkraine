using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New WeaponData", menuName = "WeaponData Asset")]
public class WeaponData : ScriptableObject
{
    [SerializeField]
    private string weaponName;
    [SerializeField]
    private string weaponDescription;
    [SerializeField]
    private Texture2D weaponImage;
    [SerializeField]
    private int russiansPerSecond;
    [SerializeField]
    private float hoursUntilDissapears;


    public string WeaponName { get { return weaponName; } }
    public string WeaponDescription { get { return weaponDescription; } }
    public Texture2D WeaponImage { get { return weaponImage; } }
    public int RussiansPerSecond { get { return russiansPerSecond; } }
    public float HoursUntilDissapears { get { return hoursUntilDissapears; } }
}

