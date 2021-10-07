using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PhysicsCarController : MonoBehaviour
{
   
    public FixedJoystick CarControlJoystick;
    public List<AxleInfo> axleInfos;  
    public float maxMotorTorque;   // maximum torque the motor can apply to wheel;
    public float AngleDirrectionToLeft;
    public float AngleDirrectionToRight;
    public float AngleForwardToDirrection;
    public float MaxSteeringAngle;
    public float Brake;
    public float ExtraRotationSpeed;

    float motor;
    float steering;

    public void Start()
    {
        

    }
    public void FixedUpdate()
    {
        Vector3 Dirrection = CarControlJoystick;

        AngleForwardToDirrection = Vector3.Angle(gameObject.transform.forward, Dirrection);
        AngleDirrectionToRight = Vector3.Angle(Dirrection, gameObject.transform.right);
        AngleDirrectionToLeft = Vector3.Angle(Dirrection, -gameObject.transform.right);

        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + Dirrection, Color.red);
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + gameObject.transform.right, Color.green);
        Debug.DrawLine(gameObject.transform.position, gameObject.transform.position + -gameObject.transform.right, Color.yellow);

        motor = maxMotorTorque * CarControlJoystick.JoystickMagnitude;
        Brake = CarControlJoystick.JoystickMagnitude == 0 ? 1000 : 0;

        if (AngleDirrectionToLeft < 90)
        {
            steering = -Mathf.Clamp(AngleForwardToDirrection, 0, MaxSteeringAngle);
        }
        if (AngleDirrectionToRight < 90)
        {
            steering = Mathf.Clamp(AngleForwardToDirrection, 0, MaxSteeringAngle);
        }

        Quaternion LookDirrection = Quaternion.LookRotation(Dirrection); 
        if (CarControlJoystick.isDraged)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, LookDirrection, ExtraRotationSpeed);


        foreach (AxleInfo axleInfo in axleInfos) // DONT UNDERSTAND
        {
            if (axleInfo.steering)
            {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor)
            {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
                axleInfo.leftWheel.brakeTorque = Brake;
                axleInfo.rightWheel.brakeTorque = Brake;
            }
        }
    }
}

[System.Serializable] // DONT UNDERSTAND
public class AxleInfo
{
    public WheelCollider leftWheel;
    public WheelCollider rightWheel;
    public bool motor; // is this wheel attached to motor?
    public bool steering; // does this wheel apply steer angle?
}