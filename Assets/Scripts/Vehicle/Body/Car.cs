using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    Vehicle thisVehicle;
    public List<AxleInfo> axleInfos;
    public float maxSteeringAngle;
    float brake;
    public float extraRotationSpeed;

    float currentMaxSpeed;
    float motor;
    float steering;

    public float GetSteering()
    {
        return steering;
    }
    private void Start()
    {
        thisVehicle = gameObject.GetComponent<Vehicle>();
        gameObject.GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -1, 0);
    }
    void FixedUpdate()
    {
        currentMaxSpeed = thisVehicle.accelerationPower * thisVehicle.maxSpeed;

        if (thisVehicle.buttonsInput.isBraking == true) // Торможение стоит переделать
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
        WorkAxles();
    }
    void WorkAxles()
    {
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
                axleInfo.leftWheel.brakeTorque = brake;
                axleInfo.rightWheel.brakeTorque = brake;
                thisVehicle.currentSpeed = axleInfo.rightWheel.rpm;
            }
        }
    }
    void TurnToAngle(float Angle)
    {
        steering = Mathf.Clamp(Angle, -maxSteeringAngle, maxSteeringAngle);
        if (thisVehicle.accelerationPower > 0 && thisVehicle.buttonsInput.isBraking == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), extraRotationSpeed * thisVehicle.accelerationPower);
        }
        if (Mathf.Abs(Angle) > 70 && thisVehicle.buttonsInput.isBraking == false)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), extraRotationSpeed * thisVehicle.accelerationPower * Mathf.Abs(Angle) / 90);
        }
    }
    void AddAcceleration(float AccelerationPower)
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
