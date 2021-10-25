using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Vehicle ThisVehicle;
    public List<AxleInfo> axleInfos;
    public float MaxSteeringAngle;
    public float Brake;
    public float ExtraRotationSpeed;


    float CurrentMaxSpeed;
    float motor;
    float steering;
    bool isReverse;

    private void Start()
    {
        ThisVehicle = gameObject.GetComponent<Vehicle>();
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
    }
    void FixedUpdate()
    {
        CurrentMaxSpeed = ThisVehicle.AccelerationPower * ThisVehicle.MaxSpeed;
        Brake = ThisVehicle.AccelerationPower == 0 ? 1000 : 0;

        TurnToAngle(ThisVehicle.TurnAngle);
        AddAcceleration(ThisVehicle.AccelerationPower);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
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
    void TurnToAngle(float Angle)
    {
        steering = Mathf.Clamp(Angle, -MaxSteeringAngle, MaxSteeringAngle);
        if (ThisVehicle.AccelerationPower > 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), ExtraRotationSpeed * ThisVehicle.AccelerationPower);
        }
        if (Mathf.Abs(Angle) > 70)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), ExtraRotationSpeed * ThisVehicle.AccelerationPower * Mathf.Abs(Angle) / 90 );
        }

    }
    void AddAcceleration(float AccelerationPower)
    {
        if (AccelerationPower > 0 && ThisVehicle.CurrentSpeed < CurrentMaxSpeed)
        {
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else if (AccelerationPower < 0 && ThisVehicle.CurrentSpeed > ThisVehicle.MaxReverseSpeed)
        {
            if (ThisVehicle.CurrentSpeed > 10)
            {
                Brake = ThisVehicle.BrakePower;
            }
            motor = ThisVehicle.AccelerationSpeed * AccelerationPower;
        }
        else
        {
            motor = 0;
        }
    }

}
