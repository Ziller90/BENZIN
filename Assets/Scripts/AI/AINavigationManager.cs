using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AINavigationManager : MonoBehaviour
{
    public Transform vehicle;
    public float BrakeDistanceToTarget;
    public JoystickInputManager AIVehicleInput;
    public ButtonsInput buttonsInput;
    public Vector3 target;
    public float OldDistanceToTarget;

    public Vector3[] corners;
    NavMeshAgent navMeshAgent;
    Vector3 startPosition;
    Vector3 nextCorner;
    public Color GizmosTargetColor;

    public delegate void GotTarget();

    public GotTarget gotTarget;
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
        if (Vector3.Distance(vehicle.position, target) > BrakeDistanceToTarget)
        {
            corners = navMeshAgent.path.corners;
            navMeshAgent.SetDestination(target);
            if (corners.Length > 1)
              nextCorner = corners[1];
            AIVehicleInput.Direction = (nextCorner - transform.position).normalized;
            buttonsInput.isBraking = false;
            
        }
        else
        {
            AIVehicleInput.Direction = Vector3.zero;
            buttonsInput.isBraking = true;
        }
        GotMyTarget();
    }
    void GotMyTarget()
    {
        float NewDistanceToTarget = Vector3.Distance(gameObject.transform.position, target);
        if (NewDistanceToTarget < BrakeDistanceToTarget && OldDistanceToTarget > BrakeDistanceToTarget)
        {
            gotTarget();
        }
        OldDistanceToTarget = NewDistanceToTarget;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosTargetColor;
        Gizmos.DrawSphere(target, 2f);
    }
}
