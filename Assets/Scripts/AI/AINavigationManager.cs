using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AINavigationManager : MonoBehaviour
{
    public Transform vehicle;
    public float minDistanceToTarget;
    public JoystickInputManager vehicleInput;
    public ButtonsInput buttonsInput;
    public Vector3 target;
    public bool gotTarget;

    public Vector3[] corners;
    NavMeshAgent navMeshAgent;
    Vector3 startPosition;
    Vector3 nextCorner;
    
    public void SetTarget(Vector3 target)
    {
        this.target = target;
    }
    public void RemoveTarget()
    {
        target = gameObject.transform.position;
    }
    void Start()
    {
        startPosition = gameObject.transform.localPosition;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        gameObject.transform.localPosition = startPosition;


        if (Vector3.Distance(vehicle.position, target) > minDistanceToTarget)
        {
            corners = navMeshAgent.path.corners;
            navMeshAgent.SetDestination(target);
            if (corners.Length > 1)
              nextCorner = corners[1];
            vehicleInput.Direction = (nextCorner - transform.position).normalized;
            buttonsInput.isBraking = false;
        }
        else
        {
            vehicleInput.Direction = Vector3.zero;
            buttonsInput.isBraking = true;
        }
    }
}
