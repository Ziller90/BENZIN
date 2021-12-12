using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    public int exp;
    public int Level
    {
        get { return exp / 1000; }
    }
    public List<Transform> WayPoints = new List<Transform>();
    public Color GizmosRouteColor;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        Gizmos.color = GizmosRouteColor;
        for (int i = 0; i < WayPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(WayPoints[i].position, WayPoints[i + 1].position);
        }
    }
}
