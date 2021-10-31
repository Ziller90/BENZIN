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

    private void Start()
    {
        ThisVehicle = gameObject.GetComponent<Vehicle>();
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
    }
    void FixedUpdate()
    {
        CurrentMaxSpeed = ThisVehicle.AccelerationPower * ThisVehicle.MaxSpeed;
        if (ThisVehicle.ButtonsInput.isBraking == true)
        {
            Brake = ThisVehicle.MaxBrakePower;
        }
        else
        {
            Brake = 0;
        }

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
        if (ThisVehicle.AccelerationPower < 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, -Angle, 0), RotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), RotationSpeed);
            if (Mathf.Abs(Angle) > 70)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), RotationSpeed * ThisVehicle.AccelerationPower * Mathf.Abs(Angle) / 90 / 4);
            }
        }
    }
    void AddAcceleration(float AccelerationPower) // Power -1 to 1
    {
        if (AccelerationPower > 0 && ThisVehicle.CurrentSpeed < CurrentMaxSpeed)
        {
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else if (AccelerationPower < 0 && ThisVehicle.CurrentSpeed > ThisVehicle.MaxReverseSpeed)
        {
            if (ThisVehicle.CurrentSpeed > 10)
            {
                Brake = ThisVehicle.MaxBrakePower;
            }
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else
        {
            motor = 0;
        }
    }
} 
