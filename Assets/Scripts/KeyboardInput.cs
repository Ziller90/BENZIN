using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public VehicleInputManager inputManager;
    public float Vertical;
    public float Horizontal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        inputManager.Vertical = Vertical;
        inputManager.Horizontal = Horizontal;

    }
}
