using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
     Vehicle ThisVehicle;
    public List<AxleInfo> axleInfos;
    public float Brake;
    public float RotationSpeed;

    float CurrentMaxSpeed;
    float motor;
    bool isReverse;

    private void Start()
    {
        ThisVehicle = gameObject.GetComponent<Vehicle>();
    }
    void FixedUpdate()
    {
        CurrentMaxSpeed = ThisVehicle.AccelerationPower * ThisVehicle.MaxSpeed;
        Brake = ThisVehicle.AccelerationPower == 0 ? 1000 : 0;

        TurnToAngle(ThisVehicle.TurnAngle);
        AddAcceleration(ThisVehicle.AccelerationPower);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.leftWheel.brakeTorque = Brake;
                axleInfo.rightWheel.brakeTorque = Brake;

                ThisVehicle.CurrentSpeed = axleInfo.rightWheel.rpm;
            }
        }
    }
    void TurnToAngle(float Angle) // Angle -180 to 180
    {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), RotationSpeed);
    }
    void AddAcceleration(float AccelerationPower) // Power -1 to 1
    {
        if (AccelerationPower > 0 && ThisVehicle.CurrentSpeed < CurrentMaxSpeed)
        {
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else if (AccelerationPower < 0 && ThisVehicle.CurrentSpeed > ThisVehicle.MaxReverseSpeed)
        {
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else
        {
            motor = 0;
        }
    }
} 
