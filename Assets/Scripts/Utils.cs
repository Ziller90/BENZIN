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
    public static Vector3 GetNearestPoint(Vector3 MainPoint, Vector3[] Points) 
    {
        float MinDistance = 1000000;
        Vector3 NearestPoint = new Vector3();
        foreach (Vector3 point in Points)
        {
            if (Vector3.Distance(MainPoint, point) < MinDistance)
            {
                NearestPoint = point;
            }
        }
        return NearestPoint;
    }
    public static Vector3 GetNearestPoint(Vector3 MainPoint, List<Vector3> Points)
    {
        float MinDistance = 1000000;
        Vector3 NearestPoint = new Vector3();
        foreach (Vector3 point in Points)
        {
            if (Vector3.Distance(MainPoint, point) < MinDistance)
            {
                NearestPoint = point;
            }
        }
        return NearestPoint;
    }
    public static GameObject GetNearestGameObject(GameObject MainPoint, GameObject[] Points)
    {
        float MinDistance = 1000000;
        GameObject NearestGameObject = new GameObject();
        foreach (GameObject point in Points)
        {
            if (Vector3.Distance(MainPoint.transform.position, point.transform.position) < MinDistance)
            {
                NearestGameObject = point;
            }
        }
        return NearestGameObject;
    }
    public static GameObject GetNearestGameObject(GameObject MainPoint, List<GameObject> Points)
    {
        float MinDistance = 1000000;
        GameObject NearestGameObject = new GameObject();
        foreach (GameObject point in Points)
        {
            if (Vector3.Distance(MainPoint.transform.position, point.transform.position) < MinDistance)
            {
                NearestGameObject = point;
            }
        }
        return NearestGameObject;
    }

}
