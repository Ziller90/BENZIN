using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject thisObject; 
    public float maxHealth;
    public float currentHealth;
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
    public void AddHealth(float helath)
    {
        currentHealth += helath;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
