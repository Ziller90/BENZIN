using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleInputManager : MonoBehaviour
{
    public float Horizontal;
    public float Vertical;


    public Vector3 Direction;
    public bool IsUsing;
    void Start()
    {
        
    }

    void Update()
    {
        Direction = Utils.GetDirection(Horizontal, Vertical);
        IsUsing = (Horizontal != 0 || Vertical != 0) ? true : false;
    }
}
