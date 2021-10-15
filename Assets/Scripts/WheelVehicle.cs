using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelVehicle : MonoBehaviour
{
    public InputSwitch inputSwitch;
    public VehicleInputManager inputManager;
    public List<AxleInfo> axleInfos;  
    public float AccelerationSpeed;  
    public float MaxSteeringAngle;
    public float Brake;
    public float ExtraRotationSpeed;
    public float MaxSpeed;
    public float ReverseMaxSpeed;
    public float CurrentSpeed;

    Rigidbody rigidbody;
    public float CurrentMaxSpeed;
    float motor;
    float steering;

    public void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        CurrentSpeed = ((float) ((int)(rigidbody.velocity.magnitude * 100))) / 100;

        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Mobile || inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Gamepad)
        {
            CurrentMaxSpeed = MaxSpeed * inputManager.Direction.magnitude; 
            Vector3 Direction = inputManager.Direction;
            AddAcceleration(inputManager.Direction.magnitude);
            TurnToDirrection(Direction);
        }
        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.KeyBoardAndMouse)
        {
            CurrentMaxSpeed = MaxSpeed * inputManager.Vertical;
            AddAcceleration(inputManager.Vertical);
            TurnToAngle(inputManager.Horizontal * MaxSteeringAngle);
        }

        Brake = inputManager.IsUsing ? 0 : 1000;


        foreach (AxleInfo axleInfo in axleInfos) // DONT UNDERSTAND
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
        steering = Mathf.Clamp(Angle, -MaxSteeringAngle, MaxSteeringAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, transform.rotation * Quaternion.Euler(0,Angle,0), ExtraRotationSpeed);
    }
    void AddAcceleration(float AccelerationPower)
    {
        if (CurrentSpeed < CurrentMaxSpeed && CurrentSpeed > ReverseMaxSpeed)
        {
            Debug.Log(AccelerationPower + " " + AccelerationSpeed + " " + motor );
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