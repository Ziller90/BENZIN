using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickInput : MonoBehaviour
{
    InputMaster inputActions;
    public JoystickInputManager PlayerVehicleControl;
    public JoystickInputManager PlayerGunControl;
    public ButtonsInput PlayerButtonInput;

    public Vector2 RightStick;
    public Vector2 LeftStick;
    public bool IsShooting;
    public bool IsBraking;

    private void Update()
    {
        PlayerVehicleControl.Direction = Utils.GetDirection(LeftStick.x, LeftStick.y, -35);
        PlayerGunControl.Direction = Utils.GetDirection(RightStick.x, RightStick.y, -35);

        PlayerButtonInput.isBraking = IsBraking;
        PlayerButtonInput.isShooting = IsShooting;

    }
    void Awake()
    {
        inputActions = new InputMaster();
        inputActions.Vehicle.GunIsShooting.started += ctx => StartShooting();
        inputActions.Vehicle.GunIsShooting.canceled += ctx => EndShooting();

        inputActions.Vehicle.CarIsBraking.started += ctx => StartBraking();
        inputActions.Vehicle.CarIsBraking.canceled += ctx => EndtBraking();

        inputActions.Vehicle.CarControl.performed += ctx => LeftStick = ctx.ReadValue<Vector2>();
        inputActions.Vehicle.GunControl.performed += ctx => RightStick = ctx.ReadValue<Vector2>();

        inputActions.Vehicle.CarControl.canceled += ctx => LeftStick = Vector2.zero;
        inputActions.Vehicle.GunControl.canceled += ctx => RightStick = Vector2.zero;
    }

    void StartShooting()
    {
        IsShooting = true;
    }
    void EndShooting()
    {
        IsShooting = false;
    }
    void StartBraking()
    {
        IsBraking = true;
    }
    void EndtBraking()
    {
        IsBraking = false;
    }


    public void OnEnable()
    {
        inputActions.Vehicle.Enable();
    }
    public void OnDisable()
    {
        inputActions.Vehicle.Disable();
    }
}
