using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunShoot : MonoBehaviour
{
    public ButtonsInput buttonsInput;
    public GameObject bullet;
    public Transform bulletInstantiatePoint;
    public float damage;
    public float fireRateInMinute;
    public Animator gunAnimator;
    bool isShooting;
    bool isReloaded = true;

    public void FixedUpdate()
    {
        isShooting = buttonsInput.isShooting;
        if (isShooting && isReloaded)
        {
            Shot();
        }
    }
    public void Shot()
    {
        gunAnimator.SetTrigger("Shot");
        GameObject NewBullet = Instantiate(bullet, bulletInstantiatePoint.position, bulletInstantiatePoint.rotation);
        isReloaded = false;
        StartCoroutine("Reload");
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(60 / fireRateInMinute);
        isReloaded = true;
    }
}

