using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    public GameObject gameObjectToFollow;
    public Rigidbody rigidBody;
    public Vector3 offset;
    public float followSpeed;


    void FixedUpdate()
    {
        Vector3 GoalPoint = gameObjectToFollow.transform.position + offset;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, GoalPoint, followSpeed );
    }
}
