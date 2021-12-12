using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunShoot : MonoBehaviour
{
    ButtonsInput buttonsInput;
    public VehicleControlManager controlManager;
    public GameObject ThisCar;
    public GameObject bullet;
    public Transform bulletInstantiatePoint;
    public float fireRateInMinute;
    public Animator gunAnimator;
    bool isShooting;
    bool isReloaded = true;

    public void LateUpdate()
    {
        buttonsInput = controlManager.CurrentButtonInput;
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
        NewBullet.GetComponent<Bullet>().shootingObject = ThisCar;
        isReloaded = false;
        StartCoroutine("Reload");
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(60 / fireRateInMinute);
        isReloaded = true;
    }
}

