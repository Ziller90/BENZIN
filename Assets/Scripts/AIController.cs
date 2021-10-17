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
    public AIVNavigationManager navigationManager;

    public Vector3 MoveTarget;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case State.Idle:
                MoveTarget = gameObject.transform.position;
                break;
            case State.Attacking:
                MoveTarget = ObjectToAttack.position;
                break;
            case State.Following:
                MoveTarget = ObjectToFollow.position;
                break;
            case State.Patrolling:
                break;
        }
    }
}
