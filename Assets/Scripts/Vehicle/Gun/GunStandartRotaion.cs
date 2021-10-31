using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunStandartRotaion : MonoBehaviour
{
    public JoystickInputManager GunControlJoystick;
    public float GunRotationSpeed;
    public Transform Car;

    Vector3 Direction;
    Quaternion CarRotationAngle;

    void FixedUpdate()
    {
        CarRotationAngle = Quaternion.Euler(0, -Car.rotation.eulerAngles.y, 0);
        Quaternion LookDirrection = new Quaternion();
        Direction = CarRotationAngle * GunControlJoystick.Direction;
        if (Direction != Vector3.zero)
           LookDirrection = Quaternion.LookRotation(Direction);

        if (GunControlJoystick.IsUsing)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, LookDirrection, GunRotationSpeed);
        }
    }
}
