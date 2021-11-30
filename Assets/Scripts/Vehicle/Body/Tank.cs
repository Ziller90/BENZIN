using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    Vehicle thisVehicle;
    public List<AxleInfo> axleInfos;
    public float brake;
    public float rotationSpeed;

    float currentMaxSpeed;
    float motor;

    private void Start()
    {
        thisVehicle = gameObject.GetComponent<Vehicle>();
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
    }
    void FixedUpdate()
    {
        currentMaxSpeed = thisVehicle.accelerationPower * thisVehicle.maxSpeed;

        if (thisVehicle.buttonsInput.isBraking == true) 
        {
            brake = thisVehicle.maxBrakePower;
        }
        else if (thisVehicle.accelerationPower != 0)
        {
            brake = 0;
        }
        else
        {
            brake = thisVehicle.minBrakePower;
        }

        TurnToAngle(thisVehicle.turnAngle);
        AddAcceleration(thisVehicle.accelerationPower);

        foreach (AxleInfo axleInfo in axleInfos)
        {
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;

                thisVehicle.currentSpeed = axleInfo.rightWheel.rpm;
            }
        }
    }
    void TurnToAngle(float Angle) // Angle -180 to 180
    {
        if (thisVehicle.accelerationPower < 0)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, -Angle, 0), rotationSpeed);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), rotationSpeed);
            if (Mathf.Abs(Angle) > 70)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), rotationSpeed * thisVehicle.accelerationPower * Mathf.Abs(Angle) / 90 / 4);
            }
        }
    }
    void AddAcceleration(float AccelerationPower) // Power -1 to 1
    {
        if (AccelerationPower > 0 && thisVehicle.currentSpeed < currentMaxSpeed)
        {
            motor = thisVehicle.accelerationSpeed * AccelerationPower;
        }
        else if (AccelerationPower < 0 && thisVehicle.currentSpeed > thisVehicle.maxReverseSpeed)
        {
            if (thisVehicle.currentSpeed > 10)
            {
                brake = thisVehicle.maxBrakePower;
            }
            motor = thisVehicle.accelerationSpeed * AccelerationPower;
        }
        else
        {
            motor = 0;
        }
    }
} 
