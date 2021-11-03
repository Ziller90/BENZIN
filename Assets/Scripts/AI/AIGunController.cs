using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGunController : MonoBehaviour
{
    public Vector3 Direction;
    public float DistanceToAttack;
    public JoystickInputManager GunController;
    [HideInInspector] public Transform Target;
    public Transform DefaultTarget;
    public ButtonsInput EnemyButtonInput;
    public void SetAttackTarget(Transform Target)
    {
        this.Target = Target;
    }
    public void RemoveAttackTarget()
    {
        Target = DefaultTarget;
    }
    void Start()
    {
        Target = DefaultTarget;
    }
    void Update()
    {
        Direction = Target.position - gameObject.transform.position;
        GunController.Direction = new Vector3(Direction.x, 0, Direction.z);

        if (Target != DefaultTarget && Vector3.Distance(Target.position, gameObject.transform.position) < DistanceToAttack) 
        {
            EnemyButtonInput.isShooting = true;
        }
        else
        {
            EnemyButtonInput.isShooting = false;
        }

    }
}
