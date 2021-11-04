using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject ThisObject; // will be deprecated
    public float MaxHealth;
    float CurrentHealth;
    public void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(ThisObject);
    }
    public void GetDamage(float Damage)
    {
        CurrentHealth -= Damage;
    }
}
