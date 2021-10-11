using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WheelVechicle : MonoBehaviour
{
    public InputSwitch inputSwitch;
    public FixedJoystick CarControlJoystick;
    public List<AxleInfo> axleInfos;  
    public float AccelerationSpeed;  
    public float MaxSteeringAngle;
    public float Brake;
    public float ExtraRotationSpeed;
    public float MaxSpeed;
    public float CurrentSpeed;

    Rigidbody rigidbody;
    float CurrentMaxSpeed;
    float motor;
    float steering;

    public void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        CurrentMaxSpeed = MaxSpeed * CarControlJoystick.JoystickMagnitude;
        CurrentSpeed = ((float) ((int)(rigidbody.velocity.magnitude * 100))) / 100;

        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Mobile || inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.Gamepad)
        {
            Vector3 Dirrection = CarControlJoystick.Dirrection;
            AddAcceleration(CarControlJoystick.JoystickMagnitude);
            TurnToDirrection(Dirrection);
        }
        if (inputSwitch.CurrentInputSystem == InputSwitch.InputSystem.KeyBoardAndMouse)
        {
            AddAcceleration(CarControlJoystick.Vectical);
            TurnToAngle(CarControlJoystick.Horizontal * MaxSteeringAngle);
        }

        Brake = CarControlJoystick.JoystickMagnitude == 0 ? 1000 : 0;


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
    void TurnToDirrection(Vector3 Dirrection)
    {
        float AngleForwardToDirrection = Vector3.Angle(gameObject.transform.forward, Dirrection);
        float AngleDirrectionToRight = Vector3.Angle(Dirrection, gameObject.transform.right);
        float AngleDirrectionToLeft = Vector3.Angle(Dirrection, -gameObject.transform.right);

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
        if (CurrentSpeed < CurrentMaxSpeed)
        {
            motor = AccelerationSpeed * AccelerationPower;
        }
        else 
        {
            motor = 0;
        }
    }
    void PaintGizmos(Vector3 Dirrection)
    {
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + Dirrection, Color.red);
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.right, Color.green);
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + -gameObject.transform.right, Color.yellow);
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