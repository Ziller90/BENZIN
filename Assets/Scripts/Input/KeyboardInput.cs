using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    public JoystickInputManager inputManager;
    public ButtonsInput buttonsInput;
    public float Vertical;
    public float Horizontal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        buttonsInput.isBraking = Input.GetKey(KeyCode.Space);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            Vertical = 0;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Vertical = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Vertical = -1;
        }
        else
        {
            Vertical = 0;
        }

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            Horizontal = 0;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Horizontal = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            Horizontal = -1;
        }
        else
        {
            Horizontal = 0;
        }

        inputManager.Vertical = Vertical;
        inputManager.Horizontal = Horizontal;

    }
}
