using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttitudeIndicator : MonoBehaviour
{
    [SerializeField] RawImage rollIndicator;
    [SerializeField] GameObject pitchIndicator;
    [SerializeField] GameObject plane;
     
    void Update()
    {
        rollIndicator.transform.rotation = Quaternion.Euler(0, 0, plane.transform.rotation.eulerAngles.z);
        pitchIndicator.transform.Translate(0, PlaneGyroSteering.PitchAccel, 0);
    }
}
