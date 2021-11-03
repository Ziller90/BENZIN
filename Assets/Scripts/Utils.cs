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
    public static Vector3 GetDirection(float Horizontal, float Vertical, int FixAngle)
    {
        Quaternion FixQuaternion = Quaternion.Euler(0, FixAngle, 0);
        Vector3 Direction = Vector3.ClampMagnitude(new Vector3(Horizontal, 0, Vertical), 1);
        Direction = FixQuaternion * Direction;
        return Direction;
    }
 
    public static float Round(float Number, int RoundIndex)
    {
        float temp = Number * RoundIndex;
        temp = (int)temp;
        temp = temp / RoundIndex;
        return (temp);
    }


}
