using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGunController : MonoBehaviour
{
    public Vector3 direction;
    public float distanceToAttack;
    public JoystickInputManager AIGunInput;
    [HideInInspector] public Transform target;
    public Transform defaultTarget;
    public ButtonsInput AIButtonInput;
    public void SetAttackTarget(Transform Target)
    {
        this.target = Target;
    }
    public void RemoveAttackTarget()
    {
        target = defaultTarget;
    }
    void Start()
    {
        target = defaultTarget;
    }
    void Update()
    {
        if (target != null)
        {
            if (target != defaultTarget)
            {
                direction = target.position - gameObject.transform.position;
                AIGunInput.Direction = new Vector3(direction.x, 0, direction.z);
            }

            if (target != defaultTarget && Vector3.Distance(target.position, gameObject.transform.position) < distanceToAttack)
            {
                AIButtonInput.isShooting = true;
            }
            else
            {
                AIButtonInput.isShooting = false;
            }
        }

    }
}
