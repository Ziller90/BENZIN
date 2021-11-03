using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunShoot : MonoBehaviour
{
    public ButtonsInput buttonsInput;
    public GameObject Bullet;
    public Transform BulletInstantiatePoint;
    public float Damage;
    public float FireRateInMinute;
    bool IsShooting;
    bool IsReloaded = true;

    public void FixedUpdate()
    {
        IsShooting = buttonsInput.isShooting;
        if (IsShooting && IsReloaded)
        {
            Shot();
        }
    }
    public void Shot()
    {
        GameObject NewBullet = Instantiate(Bullet, BulletInstantiatePoint.position, BulletInstantiatePoint.rotation);
        IsReloaded = false;
        StartCoroutine("Reload");
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(60 / FireRateInMinute);
        IsReloaded = true;
    }
}

