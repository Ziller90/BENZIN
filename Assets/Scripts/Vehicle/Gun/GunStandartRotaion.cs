using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStandartRotaion : MonoBehaviour
{
    JoystickInputManager gunControlJoystick;
    public VehicleControlManager controlManager;
    public float gunRotationSpeed;
    public Transform car;

    Vector3 direction;
    Quaternion carRotationAngle;

    void FixedUpdate()
    {
        gunControlJoystick = controlManager.CurrentGunInput;
        carRotationAngle = Quaternion.Euler(0, -car.rotation.eulerAngles.y, 0);
        Quaternion LookDirrection = new Quaternion();
        direction = carRotationAngle * gunControlJoystick.Direction;
        if (direction != Vector3.zero)
           LookDirrection = Quaternion.LookRotation(direction);

        if (gunControlJoystick.IsUsing)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, LookDirrection, gunRotationSpeed);
        }
    }
}
