using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public JoystickInputManager GunControlJoystick;
    public float GunRotationSpeed;
    public Transform Car;


    Vector3 Direction;
    Quaternion FixAngle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FixAngle = Quaternion.Euler(0, -Car.rotation.eulerAngles.y, 0);

        Direction = FixAngle * GunControlJoystick.Direction;
        Quaternion LookDirrection = Quaternion.LookRotation(Direction);
        if (GunControlJoystick.IsUsing)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, LookDirrection, GunRotationSpeed);
        }
    }
    void Shoot()
    {

    }

}
