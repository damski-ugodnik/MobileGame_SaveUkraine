using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "New Airplane Specs", menuName = "Airplane Specs", order = 52)]
public class AirplaneSpecs : ScriptableObject
{
    [SerializeField] private float power;
    [SerializeField] private float maneuverability;

    public float Maneuverability { get { return maneuverability; } }
    public float Power { get { return power; } }
}

