using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolowing : MonoBehaviour
{
    public Transform gameObjectToFollow;
    public GameManager gameManager;
    public Rigidbody rigidBody;
    public Vector3 offset;
    public float DistanceToVehicle;
    public float followSpeed;

    public void Start()
    {

    }
    void FixedUpdate()
    {
        gameObjectToFollow = gameManager.cameraFollowingPoint;
        Vector3 GoalPoint = gameObjectToFollow.position + offset * DistanceToVehicle;
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, GoalPoint, followSpeed );
    }
}
