using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public FixedJoystick GunControlJoystick;
    public float GunRotationSpeed;
    public Transform Car;


    Vector3 Dirrection;
    Quaternion FixAngle;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FixAngle = Quaternion.Euler(0, -Car.rotation.eulerAngles.y, 0);

        Dirrection = FixAngle * GunControlJoystick.Dirrection;
        Quaternion LookDirrection = Quaternion.LookRotation(Dirrection);
        if (GunControlJoystick.isDraged)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, LookDirrection, GunRotationSpeed);
            if (GunControlJoystick.JoystickMagnitude == 2)
            {
                Debug.Log("Bullet");
            }
        }
    }
    void Shoot()
    {

    }

}
