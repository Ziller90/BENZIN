using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AINavigationManager : MonoBehaviour
{
    public Transform Vehicle;
    public float MinDistanceToTarget;
    public JoystickInputManager VehicleInput;
    public ButtonsInput buttonsInput;
    public Vector3 Target;
    public bool GotTarget;

    public Vector3[] Corners;
    NavMeshAgent navMeshAgent;
    Vector3 StartPosition;
    Vector3 NextCorner;
    
    public void SetTarget(Vector3 target)
    {
        Target = target;
    }
    public void RemoveTarget()
    {
        Target = gameObject.transform.position;
    }
    void Start()
    {
        StartPosition = gameObject.transform.localPosition;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        gameObject.transform.localPosition = StartPosition;


        if (Vector3.Distance(Vehicle.position, Target) > MinDistanceToTarget)
        {
            Corners = navMeshAgent.path.corners;
            navMeshAgent.SetDestination(Target);
            if (Corners.Length > 1)
              NextCorner = Corners[1];
            VehicleInput.Direction = (NextCorner - transform.position).normalized;
            buttonsInput.isBraking = false;
        }
        else
        {
            VehicleInput.Direction = Vector3.zero;
            buttonsInput.isBraking = true;
        }
    }
}
