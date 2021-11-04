using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Vehicle : MonoBehaviour 
{
    public InputSwitch inputSwitch;
    public JoystickInputManager inputManager;
    public ButtonsInput buttonsInput;
    public float accelerationSpeed;  
    public float maxSpeed;
    public float maxReverseSpeed;
    public float maxBrakePower;
    public float minBrakePower;


    [HideInInspector] public float accelerationPower;
    [HideInInspector] public float turnAngle;

    public float currentSpeed;

    public void FixedUpdate()
    {
        if (inputManager.CurrentJoystickType == JoystickInputManager.JoystickType.Joystick)
        {
            accelerationPower = inputManager.Direction.magnitude;
            turnAngle = GetTurnAngle(inputManager.Direction);
        }
        if (inputManager.CurrentJoystickType == JoystickInputManager.JoystickType.Keyboard)
        {
            accelerationPower = inputManager.Vertical;
            turnAngle = 45f * inputManager.Horizontal;
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