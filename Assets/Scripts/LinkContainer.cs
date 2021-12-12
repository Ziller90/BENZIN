using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkContainer : MonoBehaviour
{
    public JoystickInputManager playerVehicleInput;
    public JoystickInputManager playerGunInput;
    public ButtonsInput playerButtonInput;

    public JoystickInputManager NoneVehicleInput;
    public JoystickInputManager NoneGunInput;
    public ButtonsInput NoneButtonInput;

    public Camera mainCamera;
    public Transform healthBarList;

    public static LinkContainer instance;
    public void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
