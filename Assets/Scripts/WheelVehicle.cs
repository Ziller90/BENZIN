using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelVehicle : MonoBehaviour
{
    public InputSwitch inputSwitch;
    public JoystickInputManager inputManager;
    public List<AxleInfo> axleInfos;  
    public float AccelerationSpeed;  
    public float MaxSteeringAngle;
    public float Brake;
    public float RotationSpeed;
    public float MaxSpeed;
    public float ReverseMaxSpeed;
    public float CurrentSpeed;
    public bool isTank;
    public bool isAI;

    public float CurrentMaxSpeed;
    float motor;
    float steering;
    public bool isReverse;

    public void Start()
    {

    }
    public void FixedUpdate()
    {
       

        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Mobile || inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Gamepad || isAI == true)
        {
            CurrentMaxSpeed = Mathf.Clamp(MaxSpeed * inputManager.Direction.magnitude, ReverseMaxSpeed, MaxSpeed); 
            Vector3 Direction = inputManager.Direction;
            AddAcceleration(inputManager.Direction.magnitude);
            TurnToDirrection(Direction);
        }
        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.KeyBoardAndMouse && isAI == false)
        {
            CurrentMaxSpeed = Mathf.Clamp(MaxSpeed * inputManager.Vertical, ReverseMaxSpeed, MaxSpeed);
            isReverse = inputManager.Vertical <= 0 ? true : false;
            AddAcceleration(inputManager.Vertical);
            TurnToAngle(inputManager.Horizontal * MaxSteeringAngle);
        }

        Brake = inputManager.IsUsing ? 0 : 1000;


        foreach (AxleInfo axleInfo in axleInfos) 
        {
            if (axleInfo.steering && isTank == false)
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
                CurrentSpeed = axleInfo.rightWheel.rpm;
            }
        }
    }
    void TurnToDirrection(Vector3 Direction)
    {
        float AngleForwardToDirrection = Vector3.Angle(gameObject.transform.forward, Direction);
        float AngleDirrectionToRight = Vector3.Angle(Direction, gameObject.transform.right);
        float AngleDirrectionToLeft = Vector3.Angle(Direction, -gameObject.transform.right);

        if (AngleDirrectionToLeft < 90)
        {
            TurnToAngle(-AngleForwardToDirrection);
        }
        if (AngleDirrectionToRight < 90)
        {
            TurnToAngle(AngleForwardToDirrection);
        }
    }

    void TurnToAngle(float Angle)
    {
        if (isTank)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), RotationSpeed);
        }
        else
        {
            steering = Mathf.Clamp(Angle, -MaxSteeringAngle, MaxSteeringAngle);
            if (isReverse == false)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0, Angle, 0), RotationSpeed);
        }
    }
    void AddAcceleration(float AccelerationPower)
    {
        if (AccelerationPower > 0 && CurrentSpeed < CurrentMaxSpeed)
        {
            motor = AccelerationSpeed * AccelerationPower;
        }
        else if (AccelerationPower < 0 && CurrentSpeed > ReverseMaxSpeed)
        {
            motor = AccelerationSpeed * AccelerationPower;
        }
        else
        {
            motor = 0;
        }
    }
}

[System.Serializable] // DONT UNDERSTAND
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}