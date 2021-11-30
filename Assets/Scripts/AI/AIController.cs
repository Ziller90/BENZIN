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
    public State currentState;
    public AINavigationManager navigationManager;
    public AIGunController gunController;
    public AISensors sensors;
    public List<Transform> patrolWayPoints;
    public int nextWayPointIndex;
    public float distanceToStop;

    void Update()
    {
        if (sensors.enemiesInDetectionZone.Count != 0)
        {
            currentState = State.Attacking;
            Vector3 Offset = (gameObject.transform.position - sensors.GetEnemy().transform.position).normalized * distanceToStop;;
            navigationManager.SetTarget(sensors.GetEnemy().transform.position + Offset);
            gunController.SetAttackTarget(sensors.GetEnemy().transform);

        }
        else if (patrolWayPoints.Count != 0)
        {
            currentState = State.Patroling;
            navigationManager.SetTarget(patrolWayPoints[nextWayPointIndex].position);
            if (navigationManager.gotTarget == true)
            {
                SetNextWaypoint();
            }
            gunController.RemoveAttackTarget();
        }
        else
        {
            currentState = State.Idle;
            navigationManager.RemoveTarget();
            gunController.RemoveAttackTarget();
        }
    }
    public void SetNextWaypoint()
    {
        if ((patrolWayPoints.Count - 1) < (nextWayPointIndex + 1))
        {
            nextWayPointIndex = 0;
        }
        else
        {
            nextWayPointIndex++;
        }
    }
}
