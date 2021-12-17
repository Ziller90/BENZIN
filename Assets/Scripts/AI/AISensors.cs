using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISensors : MonoBehaviour
{
    public List<GameObject> fractionInitsInDetectionZone;
    public List<GameObject> enemiesInDetectionZone;
    GameObject nearestEnemy;
    public FractionMarker objectFractionMarker;

    public GameObject GetEnemy()
    {
        return GetNearestEnemy();
    }

    public void Update()
    {
        foreach (GameObject unit in fractionInitsInDetectionZone)
        {
            if (unit != null)
            {
                FractionMarker unitMarker = unit.GetComponent<FractionMarker>();
                if (unitMarker.objectFraction != objectFractionMarker.objectFraction && unitMarker.objectFraction != FractionMarker.Fraction.None)
                {
                    if (enemiesInDetectionZone.Contains(unit) == false)
                    {
                        enemiesInDetectionZone.Add(unit);
                    }
                }
                else
                {
                    enemiesInDetectionZone.Remove(unit);
                }
            }
            else
            {
                enemiesInDetectionZone.Remove(unit);
                fractionInitsInDetectionZone.Remove(unit);
            }
        }
    }


    // First step. Find every fraction unit in range
    private void OnTriggerEnter(Collider NewTrigger)
    {
        if (NewTrigger.gameObject.GetComponent<FractionMarker>() != null) 
        {
             fractionInitsInDetectionZone.Add(NewTrigger.gameObject);
        }
    }
    private void OnTriggerExit(Collider Trigger)
    {
        if (fractionInitsInDetectionZone.Contains(Trigger.gameObject))
        {
            fractionInitsInDetectionZone.Remove(Trigger.gameObject);
        }
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
