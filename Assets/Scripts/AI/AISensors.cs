using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public bool seeEnemy;
    public List<GameObject> enemiesInDetectionZone;

    GameObject nearestEnemy;
    public GameObject vehicle;
    public FractionMarker vehicleFractionMarker;

    public GameObject GetEnemy()
    {
        return nearestEnemy;
    }
    private void FixedUpdate()
    {
        if (enemiesInDetectionZone.Count > 0)
           nearestEnemy = GetNearestEnemy();
    }

    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
            if (NewTrigger.gameObject.GetComponent<FractionMarker>().objectFraction != vehicleFractionMarker.objectFraction)
            {
                enemiesInDetectionZone.Add(NewTrigger.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider Trigger)
    {
        if (enemiesInDetectionZone.Contains(Trigger.gameObject))
        {
            enemiesInDetectionZone.Remove(Trigger.gameObject);
        }
    }
    public GameObject GetNearestEnemy()
    {
        float MinDistance = 1000000;
        foreach (GameObject point in enemiesInDetectionZone)
        {
            if (Vector3.Distance(gameObject.transform.position, point.transform.position) < MinDistance)
            {
                nearestEnemy = point;
            }
        }
        return nearestEnemy;
    }
}
