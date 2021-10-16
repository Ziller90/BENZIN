using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public JoystickInputManager JoystickInputManager;
    public Transform Vehicle;
    public Camera MainCamera;
    public Vector3 VehicleScreenPosition;
    public Vector3 MousePosition;
    public Vector3 Dirrection;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VehicleScreenPosition = MainCamera.WorldToScreenPoint(Vehicle.position);
        MousePosition = Input.mousePosition;
        Dirrection = MousePosition - VehicleScreenPosition;
        Dirrection = Vector3.ClampMagnitude(Dirrection, 1);
        Dirrection = Utils.GetDirection(Dirrection.x, Dirrection.y);
        JoystickInputManager.Direction = Dirrection;



    }
}
