using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public enum State
    {
        Following,
        Attacking,
        Patrolling,
        Idle,
    }
    public State CurrentState;
    public Transform ObjectToFollow;
    public Transform ObjectToAttack;
    public AINavigationManager navigationManager;
    public AISensors Sensors;

    public float MinDistanceToAttack;
    public Vector3 MoveTarget;

    public GameObject NearestEnemy;

    void Update()
    {
        SelectState();
        PerformStateBehaviour();
    }
    public void SelectState()
    {
        if (Sensors.EnemiesInDetectionZone.Count != 0)
        {
            CurrentState = State.Following;
            ObjectToFollow = Sensors.NearestEnemy.transform;
        }
        else
        {
            CurrentState = State.Idle;
        }
    }
    public void PerformStateBehaviour()
    {
        switch (CurrentState)
        {
            case State.Idle:
                navigationManager.SetTarget(gameObject.transform);
                break;
            case State.Attacking:

                break;
            case State.Following:
                navigationManager.SetTarget(ObjectToFollow);
                break;
            case State.Patrolling:
                break;
        }
    }
}
