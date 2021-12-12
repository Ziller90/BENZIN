using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public List<GameObject> enemiesInDetectionZone;

    GameObject nearestEnemy;
    public GameObject vehicle;
    public FractionMarker vehicleFractionMarker;

    public GameObject GetEnemy()
    {
        return GetNearestEnemy();
    }
    public void Update()
    {
        foreach(GameObject enemy in enemiesInDetectionZone)
        {
            if (enemy == null)
            {
                enemiesInDetectionZone.Remove(enemy);
                break;
            }
        }
    }
    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
            if (NewTrigger.gameObject.GetComponent<FractionMarker>().objectFraction != vehicleFractionMarker.objectFraction && NewTrigger.gameObject.GetComponent<FractionMarker>().objectFraction != FractionMarker.Fraction.None)
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
            if (point != null)
            {
                if (Vector3.Distance(gameObject.transform.position, point.transform.position) < MinDistance)
                {
                    nearestEnemy = point;
                    MinDistance = Vector3.Distance(gameObject.transform.position, point.transform.position);
                }
            }
        }
        return nearestEnemy;
    }
}
