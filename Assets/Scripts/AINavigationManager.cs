using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIVNavigationManager : MonoBehaviour
{
    public Transform Vehicle;
    public float MinDistanceToTarget;
    public JoystickInputManager VehicleInput;
    public Transform Target;

    Vector3[] Corners;
    NavMeshAgent navMeshAgent;
    Vector3 StartPosition;
    Vector3 NextCorner;
    
    public void SetTarget(Transform target)
    {
        Target = target;
    }
    void Start()
    {
        StartPosition = gameObject.transform.localPosition;
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localPosition = StartPosition;
        if (Vector3.Distance(Vehicle.position, Target.position) > MinDistanceToTarget)
        {
            Corners = navMeshAgent.path.corners;
            navMeshAgent.SetDestination(Target.position);
            NextCorner = Corners[1];
            VehicleInput.Direction = (NextCorner - transform.position).normalized;
        }
        else
        {
            VehicleInput.Direction = Vector3.zero;
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Vector3 corner in Corners)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(corner, 0.5f);
        }
        Gizmos.DrawRay(gameObject.transform.position, (NextCorner - transform.position).normalized);
    }
}
