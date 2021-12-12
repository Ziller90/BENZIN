using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleControlManager : MonoBehaviour
{
    [HideInInspector]  public JoystickInputManager PlayerVehicleInput;
    [HideInInspector]  public JoystickInputManager PlayerGunInput;
    [HideInInspector]  public ButtonsInput PlayerButtonInput;

    [HideInInspector] public JoystickInputManager NoneVehicleInput;
    [HideInInspector] public JoystickInputManager NoneGunInput;
    [HideInInspector] public ButtonsInput NoneButtonInput;

    public JoystickInputManager AIVehicleInput;
    public JoystickInputManager AIGunInput;
    public ButtonsInput AIButtonInput;


    [HideInInspector] public JoystickInputManager CurrentVehicleInput;
    [HideInInspector] public JoystickInputManager CurrentGunInput;
    [HideInInspector] public ButtonsInput CurrentButtonInput;

    public enum ControlMaster
    {
        Player,
        AI,
        None
    }
    public ControlMaster controlMaster;
    public void Start()
    {
        PlayerVehicleInput = LinkContainer.instance.playerVehicleInput;
        PlayerGunInput = LinkContainer.instance.playerGunInput;
        PlayerButtonInput = LinkContainer.instance.playerButtonInput;

        NoneVehicleInput = LinkContainer.instance.NoneVehicleInput;
        NoneGunInput = LinkContainer.instance.NoneGunInput;
        NoneButtonInput = LinkContainer.instance.NoneButtonInput;

        SelectInputController();
    }
    void Update()
    {
        SelectInputController();
    }
    void SelectInputController()
    {
        switch(controlMaster)
        {
            case ControlMaster.Player:
                CurrentVehicleInput = PlayerVehicleInput;
                CurrentGunInput = PlayerGunInput;
                CurrentButtonInput = PlayerButtonInput;
                break;
            case ControlMaster.AI:
                CurrentVehicleInput = AIVehicleInput;
                CurrentGunInput = AIGunInput;
                CurrentButtonInput = AIButtonInput;
                break;
            case ControlMaster.None:
                CurrentVehicleInput = NoneVehicleInput;
                CurrentGunInput = NoneGunInput;
                CurrentButtonInput = NoneButtonInput;
                break;
        }
    }
}
