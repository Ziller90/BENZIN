using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public enum State
    {
        Following,
        Attacking,
        Idle,
        Patroling
    }
    public State CurrentState;
    public AINavigationManager navigationManager;
    public AIGunController gunController;
    public AISensors Sensors;

    public List<Transform> PatrolWayPoints;
    public int NextWayPointIndex;
    
    public float DistanceToStop;

    void Update()
    {
        if (Sensors.EnemiesInDetectionZone.Count != 0)
        {
            CurrentState = State.Attacking;
            Vector3 Offset = (gameObject.transform.position - Sensors.GetEnemy().transform.position).normalized * DistanceToStop; 
            navigationManager.SetTarget(Sensors.GetEnemy().transform.position + Offset);
            gunController.SetAttackTarget(Sensors.GetEnemy().transform);
        }
        else if (PatrolWayPoints.Count != 0)
        {
            CurrentState = State.Patroling;
            navigationManager.SetTarget(PatrolWayPoints[NextWayPointIndex].position);
            if (navigationManager.GotTarget == true)
            {
                SetNextWaypoint();
            }
            gunController.RemoveAttackTarget();
        }
        else
        {
            CurrentState = State.Idle;
            navigationManager.RemoveTarget();
            gunController.RemoveAttackTarget();
        }
    }
    public void SetNextWaypoint()
    {
        if ((PatrolWayPoints.Count - 1) < (NextWayPointIndex + 1))
        {
            NextWayPointIndex = 0;
        }
        else
        {
            NextWayPointIndex++;
        }
    }
    public void Start()
    {

    }
}
