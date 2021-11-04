using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGunController : MonoBehaviour
{
    public Vector3 direction;
    public float distanceToAttack;
    public JoystickInputManager gunController;
    [HideInInspector] public Transform target;
    public Transform defaultTarget;
    public ButtonsInput enemyButtonInput;
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
        direction = target.position - gameObject.transform.position;
        gunController.Direction = new Vector3(direction.x, 0, direction.z);

        if (target != defaultTarget && Vector3.Distance(target.position, gameObject.transform.position) < distanceToAttack) 
        {
            enemyButtonInput.isShooting = true;
        }
        else
        {
            enemyButtonInput.isShooting = false;
        }

    }
}
