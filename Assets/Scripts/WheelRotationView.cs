using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationView : MonoBehaviour
{
    public Vehicle Car;
    public float SpeedFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(Car.CurrentSpeed * SpeedFactor, 0, 0);
    }
}
