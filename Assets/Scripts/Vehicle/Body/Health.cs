using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject thisObject; // will be deprecated
    public float maxHealth;
    float currentHealth;
    public void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        Destroy(thisObject);
    }
    public void GetDamage(float Damage)
    {
        currentHealth -= Damage;
    }
}
