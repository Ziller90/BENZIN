using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    public GameObject GameObjectToFollow;
    public Vector3 Offset;
    public float FollowSpeed;
    public float ADD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 GoalPoint = GameObjectToFollow.transform.position + Offset;
        gameObject.transform.position = GoalPoint;
    }
}
