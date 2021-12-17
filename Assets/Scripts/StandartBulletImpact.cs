using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandartBulletImpact : MonoBehaviour
{
    public ParticleSystem BulletCollisionExplosion;
    public Bullet bullet;
    public bool HaveExplosionSound;
    public AudioSource ExplosionSound;
    public bool AlreadyExploaded = false;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag != "Sensor" && collider.gameObject != bullet.shootingObject && collider.tag != "Bullet" && AlreadyExploaded == false)
        {
            BulletCollisionExplosion.Play();
            if (HaveExplosionSound)
            {
                ExplosionSound.Play();
            }
            AlreadyExploaded = true;
        }
    }
}
