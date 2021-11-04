using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vehicle : MonoBehaviour 
{
    public InputSwitch inputSwitch;
    public JoystickInputManager inputManager;
    public ButtonsInput ButtonsInput;
    public float AccelerationSpeed;  
    public float MaxSpeed;
    public float MaxReverseSpeed;
    public float MaxBrakePower;
    public float MinBrakePower;


    [HideInInspector] public float AccelerationPower;
    [HideInInspector] public float TurnAngle;

    public float CurrentSpeed;

    public void FixedUpdate()
    {
        if (inputManager.CurrentJoystickType == JoystickInputManager.JoystickType.Joystick)
        {
            AccelerationPower = inputManager.Direction.magnitude;
            TurnAngle = GetTurnAngle(inputManager.Direction);
        }
        if (inputManager.CurrentJoystickType == JoystickInputManager.JoystickType.Keyboard)
        {
            AccelerationPower = inputManager.Vertical;
            TurnAngle = 45f * inputManager.Horizontal;
        }
    }
    float GetTurnAngle(Vector3 Direction) 
    {
        float AngleForwardToDirrection = Vector3.Angle(gameObject.transform.forward, Direction);
        float AngleDirrectionToLeft = Vector3.Angle(Direction, -gameObject.transform.right);

        if (AngleDirrectionToLeft < 90)
        {
            return -AngleForwardToDirrection;
        }
        else
        {
            return AngleForwardToDirrection;
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