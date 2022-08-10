using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GyroController : MonoBehaviour
{
    public static bool Calibrated { get; private set; }

    private void Awake()
    {
        Calibrated = false;
    }

    public void OnCalibrate()
    {
        PlaneGyroSteering.Calibrate();
        Calibrated = true;
    }
}

public static class PlaneGyroSteering
{
    private static Quaternion calibrationPoint;

    private static bool inverted = false; // controls inversion flag

    public static void Calibrate()
    {
        calibrationPoint = DeviceRotation.Get;
    }

    public static float YawAccel
    {
        get
        {
            float yaw = DeviceRotation.Get.y - calibrationPoint.y;
            return inverted ? -yaw : yaw;

        }
    }

    public static float RollAccel
    {
        get
        {
            float roll = DeviceRotation.Get.z - calibrationPoint.z;
            roll = -roll;
            return inverted ? -roll : roll;
        }
    }

    public static float PitchAccel
    {
        get
        {
            float pitch = DeviceRotation.Get.x - calibrationPoint.x;
            pitch = -pitch;
            return inverted ? -pitch : pitch;
        }
    }
}

public static class DeviceRotation
{
    private static bool gyroInitialized = false;
    private static Quaternion baseRotation = new Quaternion(0, 0, 1, 0);
    private static Quaternion coefficient = new Quaternion(0.5f, 0.5f, -0.5f, 0.5f);

    public static bool HasGyroscope
    {
        get
        {
            return SystemInfo.supportsGyroscope;
        }
    }

    public static Quaternion Get
    {
        get
        {
            if (!gyroInitialized)
            {
                InitGyro();
            }

            return HasGyroscope
                ? ReadGyroscopeRotation()
                : Quaternion.identity;
        }
    }

    private static void InitGyro()
    {
        if (HasGyroscope)
        {
            Input.gyro.enabled = true;                // enable the gyroscope
            Input.gyro.updateInterval = 0.0167f;    // set the update interval to it's highest value (60 Hz)
        }
        gyroInitialized = true;
    }

    private static Quaternion ReadGyroscopeRotation()
    {
        return coefficient * Input.gyro.attitude * baseRotation;
    }
}

