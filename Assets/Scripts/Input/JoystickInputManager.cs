using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInputManager : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;

    public Vector3 Direction;
    public bool IsUsing;

    public JoystickType CurrentJoystickType;
    void Start()
    {
        
    }
    void Update()
    {
        IsUsing = (Horizontal != 0 || Vertical != 0) ? true : Direction.magnitude != 0 ? true : false;

        if (Direction.magnitude > 0)
        {
            CurrentJoystickType = JoystickType.Joystick;
        }
        else if (Horizontal != 0 || Vertical != 0)
        {
            CurrentJoystickType = JoystickType.Keyboard;
        }
    }
    public enum JoystickType
    {
        Keyboard,
        Joystick,
    }
}
