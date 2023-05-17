using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSteeringView : MonoBehaviour
{
    public Car car;
    public float steeringFactor;

    void Update()
    {
        gameObject.transform.localRotation = Quaternion.Euler(0, 0, car.GetSteering() * steeringFactor);
    }
}
