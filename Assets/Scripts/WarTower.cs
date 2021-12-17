using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarTower : MonoBehaviour
{
    public Transform towerHead;
    public Transform towerGun;
    public AISensors towerHeadSensor;
    public AISensors towerGunSensor;
    public Transform ObjectToAttack;
    public float towerHeadRotationSpeed;
    public float towerGunRotationSpeed;
    public LineRenderer laserRenderer;


    // Update is called once per frame
    void Update()
    {
        if (towerHeadSensor.enemiesInDetectionZone.Count > 0)
        {
            if (towerHeadSensor.GetEnemy() != null)
            {
                RotateTowardsEnemy();
                ShootLaser();
            }
        }
        else
        {
            StopShooting();
        }
    }
    public void RotateTowardsEnemy()
    {
        ObjectToAttack = towerHeadSensor.GetEnemy().transform;
        Vector3 enemyDirrection = ObjectToAttack.position - towerHead.position;
        Vector3 HeadDirrection = new Vector3(enemyDirrection.x, enemyDirrection.y + towerHead.localPosition.y, enemyDirrection.z);
        Quaternion rotationToEnemy = Quaternion.LookRotation(HeadDirrection);
        towerHead.localRotation = Quaternion.RotateTowards(towerHead.localRotation, rotationToEnemy, towerHeadRotationSpeed);

        Quaternion GunRotation = Quaternion.Euler(-90 + Vector3.Angle(enemyDirrection, HeadDirrection), towerGun.localRotation.y, towerGun.localRotation.z);
        towerGun.localRotation = Quaternion.RotateTowards(towerGun.localRotation, GunRotation, towerGunRotationSpeed);
    }
    public void ShootLaser()
    {
        laserRenderer.SetPosition(0, laserRenderer.gameObject.transform.position);
        laserRenderer.SetPosition(1, ObjectToAttack.position + new Vector3(0,1,0));
    }
    public void StopShooting()
    {
        laserRenderer.SetPosition(0, laserRenderer.gameObject.transform.position);
        laserRenderer.SetPosition(1, laserRenderer.gameObject.transform.position);
    }

}
