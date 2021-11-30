using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBulletImpact : MonoBehaviour
{
    public ParticleSystem BulletCollisionExplosion;
    public Bullet bullet;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Sensor" && collider.gameObject != bullet.shootingCar && collider.tag != "Bullet")
        {
            BulletCollisionExplosion.Play();
        }
    }
}
