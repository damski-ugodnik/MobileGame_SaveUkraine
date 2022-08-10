using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class AirplaneFlightController : MonoBehaviour
{
    [SerializeField] private AirplaneSpecs airplaneSpecs;

    private void Awake()
    {
        Time.timeScale /= 5;
        PlaneGyroSteering.Calibrate();  
    }

    private void Update()
    {
        if (GyroController.Calibrated)
        {
            SteerPlane();
            MovePlane();
        }
       
    }

  

    private void MovePlane()
    {

        transform.position += transform.forward* airplaneSpecs.Power*Time.deltaTime;
     
    }

    private void SteerPlane()
    {
        transform.Rotate(PlaneGyroSteering.PitchAccel, PlaneGyroSteering.YawAccel, PlaneGyroSteering.RollAccel);
    }
}