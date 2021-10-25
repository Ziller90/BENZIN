using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    public GameObject GameObjectToFollow;
    public Vector3 Offset;
    public float FollowSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 GoalPoint = GameObjectToFollow.transform.position + Offset;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, GoalPoint, FollowSpeed);
    }
}
