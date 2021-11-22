using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationView : MonoBehaviour
{
    public Vehicle vehicle;
    public float speedFactor;

    void Update()
    {
        gameObject.transform.Rotate(vehicle.currentSpeed * speedFactor, 0 , 0);
    }
}
