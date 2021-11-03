using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBullet : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position += gameObject.transform.forward * (Speed / 100);
    }
}
