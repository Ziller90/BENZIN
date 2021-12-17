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
    List<Transform> patrolWayPoints;
    public Route PatrollingRoute;
    public bool HavePatrollingRoute;
    public int nextWayPointIndex;
    public float distanceToStop;

    public Quaternion RandomAngle;

    public void Start()
    {
        if (HavePatrollingRoute)
          patrolWayPoints = PatrollingRoute.WayPoints;

        StartCoroutine("SetRandomAngle");
        navigationManager.gotTarget += GotTarget;
    }
    IEnumerator SetRandomAngle()
    {
        while (true)
        {
            RandomAngle = Quaternion.Euler(0, Random.Range(-30, 30), 0);
            yield return new WaitForSeconds(10);
        }
    }

    void Update()
    {
        if (sensors.enemiesInDetectionZone.Count != 0)
        {
            if (sensors.GetEnemy() != null)
            {
                currentState = State.Attacking;
                Vector3 RandomOffset = (RandomAngle * (gameObject.transform.position - sensors.GetEnemy().transform.position).normalized) * distanceToStop;
                navigationManager.SetTarget(sensors.GetEnemy().transform.position + RandomOffset);
                gunController.SetAttackTarget(sensors.GetEnemy().transform);
            }
        }
        else if (HavePatrollingRoute)
        {
            currentState = State.Patroling;
            navigationManager.SetTarget(patrolWayPoints[nextWayPointIndex].position);
            gunController.RemoveAttackTarget();
        }
        else
        {
            currentState = State.Idle;
            navigationManager.RemoveTarget();
            gunController.RemoveAttackTarget();
        }
    }
    void GotTarget()
    {
        if (currentState == State.Patroling)
        {
            SetNextWaypoint();
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
