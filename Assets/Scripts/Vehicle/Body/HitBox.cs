using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public Health ObjectHealth;
    public void GetDamage(float Damage)
    {
        ObjectHealth.GetDamage(Damage);
    }
}