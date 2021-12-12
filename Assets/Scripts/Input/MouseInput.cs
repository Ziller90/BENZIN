using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public JoystickInputManager JoystickInputManager;
    public GameManager gameManager;
    public Transform Vehicle;
    public Camera MainCamera;
    public Vector3 VehicleScreenPosition;
    public Vector3 MousePosition;
    public Vector3 Dirrection;
    public ButtonsInput ButtonsInput;
    public LayerMask TerrainLayerMask;
    public Vector3 Offset;
    public float OffsetLength;

    public void Start()
    {

    }
    void Update()
    {
        Vehicle = gameManager.cameraFollowingPoint;

        RaycastHit hit;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, TerrainLayerMask))
        {
           Offset = Vector3.ClampMagnitude((MainCamera.transform.position - hit.point), OffsetLength); 
           MousePosition = hit.point;
           MousePosition += Offset;
        }
       
        Dirrection = MousePosition - Vehicle.position;

        Dirrection = Vector3.ClampMagnitude(Dirrection, 1);
        Dirrection = Utils.GetDirection(Dirrection.x, Dirrection.z, 0);
        JoystickInputManager.Direction = Dirrection;

        ButtonsInput.isShooting = Input.GetMouseButton(0);
    }
}
