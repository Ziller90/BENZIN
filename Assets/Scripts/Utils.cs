using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static Vector3 GetDirection(float Horizontal, float Vertical)
    {
        Quaternion FixAngle = Quaternion.Euler(0, -30, 0);
        Vector3 Direction = Vector3.ClampMagnitude(new Vector3(Horizontal, 0, Vertical), 1);
        Direction = FixAngle * Direction;
        return Direction;
    }
}
