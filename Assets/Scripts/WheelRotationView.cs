using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelRotationView : MonoBehaviour
{
    public Vehicle car;
    public float speedFactor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Rotate(car.currentSpeed * speedFactor, 0, 0);
    }
}
