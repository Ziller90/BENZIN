using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSwitch : MonoBehaviour
{
    public enum InputSystem
    {
        KeyBoardAndMouse,
        Mobile,
        Gamepad
    }
    [SerializeField]
    public InputSystem CurrentInputSystem;

    public bool AllowAutoRecognition;
    public GameObject LeftVirtualJoystick;
    public GameObject RightVirtualJoystick;

    public GameObject KeyBoardMouseInput;
    public GameObject GamepadInput;
    void Start()
    {
        if (AllowAutoRecognition)
        {
            if (Application.isEditor)
            {
                if (Input.GetJoystickNames().Length > 0)
                {
                    CurrentInputSystem = InputSystem.Gamepad;
                }
                else
                {
                    CurrentInputSystem = InputSystem.KeyBoardAndMouse;
                }
            }
            else if (Application.isMobilePlatform)
            {
                CurrentInputSystem = InputSystem.Mobile;
            }
            else if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.LinuxPlayer || Application.platform == RuntimePlatform.OSXEditor)
            {
                if (Input.GetJoystickNames().Length > 0)
                {
                    CurrentInputSystem = InputSystem.Gamepad;
                }
                else
                {
                    CurrentInputSystem = InputSystem.KeyBoardAndMouse;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentInputSystem)
        {
            case InputSystem.Gamepad:
                LeftVirtualJoystick.SetActive(false);
                RightVirtualJoystick.SetActive(false);
                KeyBoardMouseInput.SetActive(false);
                GamepadInput.SetActive(true);
                break;
            case InputSystem.Mobile:
                LeftVirtualJoystick.SetActive(true);
                RightVirtualJoystick.SetActive(true);
                KeyBoardMouseInput.SetActive(false);
                GamepadInput.SetActive(false);
                break;
            case InputSystem.KeyBoardAndMouse:
                LeftVirtualJoystick.SetActive(false);
                RightVirtualJoystick.SetActive(false);
                KeyBoardMouseInput.SetActive(true);
                GamepadInput.SetActive(false);
                break;
        }
    }

}
