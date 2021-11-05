using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarView : MonoBehaviour
{
    public Transform Canvas;
    public Transform Camera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Canvas.LookAt(Camera);
    }
}
