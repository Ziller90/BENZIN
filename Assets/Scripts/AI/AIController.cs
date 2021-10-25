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
    public Transform PatrollingArea;
    public Transform ObjectToAttack;
    public AINavigationManager navigationManager;
    public AISensors Sensors;

    public float MinDistanceToAttack;
    public Vector3 MoveTarget;

    public GameObject NearestEnemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NearestEnemy = Sensors.NearestEnemy;

        if (Sensors.EnemiesInDetectionZone.Count != 0)
        {
            CurrentState = State.Following;
            ObjectToFollow = NearestEnemy.transform;
        }
        else
        {
            CurrentState = State.Idle;
        }

        switch (CurrentState)
        {
            case State.Idle:
                navigationManager.SetTarget(gameObject.transform);
                break;
            case State.Attacking:
                MoveTarget = ObjectToAttack.position;
                break;
            case State.Following:
                navigationManager.SetTarget(ObjectToFollow);
                break;
            case State.Patrolling:
                break;
        }
    }
}
