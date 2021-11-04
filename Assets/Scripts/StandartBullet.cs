using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    public float Speed;
    public float Damage;
    void Start()
    {
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.forward * (Speed / 100);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().GetDamage(Damage);
        }
    }
}
